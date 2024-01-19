using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string promptsFile = "prompts.txt";
        int n = 0;
        List<Entry> entries = new List<Entry>();
        Journal journal = new Journal(entries);
        while (n != 5)
        {
            n = Menu();
            if (n == 1)
            {
                PromptGenerator prompt = new PromptGenerator();
                string textPrompt = prompt.GetRandomPrompt(promptsFile);
                Console.WriteLine(textPrompt);
                string entryText = Console.ReadLine();
                DateTime now = DateTime.Now;
                Entry entry = new Entry(now, textPrompt, entryText);
                entries.Add(entry);
            }
            else if (n == 2)
            {
                journal.DisplayAll();
            }
            else if (n == 3)
            {
                Console.Write("What is the file name? ");
                string filename = Console.ReadLine();
                entries.Clear();

                try
                {
                    using (StreamReader sr = File.OpenText(promptsFile))
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
            else if (n == 4)
            {
                Console.Write("What is the file name? ");
                string filename = Console.ReadLine();
                journal._entries = entries;
                journal.SaveToFile(promptsFile);
            }
            else if (n == 5)
            {
                break;
            }
        }
    }
    static int Menu()
    {
        Console.WriteLine("Please select one of the following choices: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
        int n = int.Parse(Console.ReadLine());
        return n;
    }
}