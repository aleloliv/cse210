using System;
using System.IO; //library to use files in csharp
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Reflection;

// EXCEEDING REQUIREMENTS: I inserted a function to search for every txt file in the program directory to display them for the user to pick the correct one
// also, the user can directly write on the journal without having to read a prompt, or if they want to read a prompt they can still, if they decide not for 
// the prompt, the program will write an empty prompt on the journal.

class Program
{
    static void Main(string[] args)
    {
        string journalPath = "journals";
        string promptsFile = "prompts.txt"; //set the prompts file name to a string variable because it will be used multiple times through the code
        int n = 0;
        List<Entry> entries = new List<Entry>(); //created and instanced a new list of Entry type elements called entries
        Journal journal = new Journal(entries); //created and instanced a new journal object as 'journal'
        while (n != 5) //while the user doesn't press 5 the program will run
        {
            n = Menu();
            if (n == 1) // if the user press 1 they want to write something on the journal
            {
                string entryText = Console.ReadLine();
                DateTime now = DateTime.Now;
                Entry entry = new Entry(now, entryText);
                entries.Add(entry);
            }
            else if (n == 2) // if the user press 2 they want to see a prompt to inspire them to write something
            {
                PromptGenerator prompt = new PromptGenerator();
                string textPrompt = prompt.GetRandomPrompt(promptsFile);
                Console.WriteLine(textPrompt);
                string entryText = Console.ReadLine();
                DateTime now = DateTime.Now;
                Entry entry = new Entry(now, textPrompt, entryText);
                entries.Add(entry);
            }
            else if (n == 3) // if the user press 3 they want to see everything that is written on the journal
            {
                journal.DisplayAll(); // calls the DisplayAll method
            }
            else if (n == 4) // if the user press 4 they want to load a journal file
            {
                List<string> files = new List<string>();
                files = BrowseJournals();
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
                Console.Write(@"What is the file name (just type the file name, ignore folder ('journals\') and format ('.txt'))? "); // this asks the file name
                string filename = Console.ReadLine();
                entries.Clear(); // clears the entries list because the user could have written something and then loaded an existing journal, this would make it look like the thing that the user typed before loading was part of the journal, so the list must be cleared first

                try
                {
                    using (StreamReader sr = File.OpenText($@"{journalPath}\{filename}")) // opens the file that the user chose
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] lines = line.Split(",");
                            DateTime dateTime = DateTime.Parse(lines[0]);
                            string promptText = lines[1];
                            string entryText = lines[2];
                            Entry entry = new Entry(dateTime, promptText, entryText);
                            entries.Add(entry);
                            journal._entries = entries;
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine($"This journal {filename} does not exist. Or it is not loaded");
                    Console.WriteLine(e.Message);
                }
            }
            else if (n == 5) // if the user press 5 that means they want to save everything they wrote in the journal
            {
                Console.Write("What is the file name (do NOT type the file extension ('.txt'))? ");
                string filename = Console.ReadLine();
                journal._entries = entries;
                journal.SaveToFile($@"{journalPath}\{filename}.txt");
                continue;
            }
            else if (n == 6) // if the user press 6 they want to exit the program
            {
                break;
            }
            else
            {
                Console.WriteLine("This is not a valid option, please select a valid number:");
                n = Menu();
            }
        }
    }
    static int Menu()
    {
        Console.WriteLine("Please select one of the following choices: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Prompt");
        Console.WriteLine("3. Display");
        Console.WriteLine("4. Load");
        Console.WriteLine("5. Save");
        Console.WriteLine("6. Quit");
        Console.Write("What would you like to do? ");
        int n = int.Parse(Console.ReadLine());
        return n;
    }
    static List<string> BrowseJournals()
    {
        List<string> files = new List<string>();
        string path = @"journals\";
        try
        {
            var txtFiles = Directory.EnumerateFiles(path, "*.txt", SearchOption.AllDirectories);
            foreach (string file in txtFiles)
            {
                files.Add(file);
            }
            return files;
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred");
            Console.WriteLine(e.Message);
            Console.WriteLine("No journals were found to load");
        }
        return files;
    }
}