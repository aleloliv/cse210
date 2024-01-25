using System;
using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;

// EXCEEDING REQUIREMENTS: I added a function to read from a file a list of scriptures, and let the user pick one of the scriptures to memorize, 
// the scriptures can be a one verse scripture, or a multiple verses, the verses can be in sequence or scattered, the program will display the reference accordingly 
// to how the verses are in the scripture.

class Program
{
    static void Main(string[] args)
    {
        Console.Clear(); // Clears the console
        Scripture scripture = Menu(); // Calls the Menu() function
        Console.Clear(); // Clears the console
        bool isHidden = scripture.IsCompletelyHidden(); // Checks if the entire scripture is completely hidden
        string quit = ""; // Creates a string variable to hold what the user will type
        while (true)
        {
            scripture.DisplayScripture(); // displays the scripture
            Console.WriteLine("\n\nPress enter to continue or 'quit' to finish: "); 
            quit = Console.ReadLine(); // Waits for the user input
            if (quit == "quit") // if the user types 'quit' the program should stop
            {
                break;
            }
            scripture.HideRandomWord(); // hides 3 random words
            scripture.DisplayScripture(); // displays the new scripture with the random words hidden
            isHidden = scripture.IsCompletelyHidden(); // Checks if the entire scripture is completely hidden
            if (isHidden == true) // if the scripture is completely hidden, stops the program
            {
                break;
            }
            Console.Clear(); // Clears the console
        }
    }

    static List<Scripture> GetListOfScripture() // a function that reads through a file and returns a list of scriptures as result
    {
        string file = "scriptures.txt"; // creates a string to hold the file name
        List<Scripture> scriptures = new List<Scripture>(); // an empty list of scriptures
        List<List<Word>> listOfWords = new List<List<Word>>(); // an empty list of lists of words
        List<Reference> references = new List<Reference>(); // an empty list of references

        try
        {
            using (StreamReader sr = File.OpenText(file)) // opens the file for reading
            {
                while (!sr.EndOfStream) // while the end of the file is not read
                {
                    List<Word> words = new List<Word>(); // creates an empty list of words

                    string line = sr.ReadLine(); // read the line
                    string[] content = line.Split(";;"); // separates the line into two strings using the ;; as splitter
                    string referenceString = content[0]; // assign the first part to the string referenceString
                    string[] wordsString = referenceString.Split(" "); // splits again the reference to get the book name and the numbers
                    string book = wordsString[0]; // the book name is assigned to the book string
                    string[] numbers = wordsString[1].Split(":"); // the numbers are splitted to get the chapter and the verses
                    int chapter = int.Parse(numbers[0]); // the chapter is assigned to the int chapter variable
                    char[] c = numbers[1].ToCharArray(); // splits the verse numbers into individual chars
                    List<int> verses = new List<int>(); // an empty list of integers
                    string text = content[1]; // the text of the scripture is assigned to a string text variable
                    int verseNumber = 0;
                    int verse = 0;
                    bool isMoreThanOneVerse = false;
                    char separator = ' ';

                    foreach (char a in c) // for each char number this will check if there are any splitters like commas (,) or hifes (-) so it knows there are more then one verse.
                    {
                        if (a == '-' || a == ',')
                        {
                            isMoreThanOneVerse = true;
                            separator = a;
                            break;
                        }
                    }

                    if (isMoreThanOneVerse) // if there are more than one verse, this will split the numbers using the splitters detected before, and add them to the list of integers 'verses'
                    {
                        string[] versesString = numbers[1].Split(separator);
                        foreach (string v in versesString)
                        {
                            verseNumber = int.Parse(v);
                            verses.Add(verseNumber);
                        }
                    }
                    else // if there is only one verse than this will convert it into an integer
                    {
                        verse = int.Parse(numbers[1]);
                    }

                    if (verses.Count != 0) // if the list of integers verses is longer than 0, than this will know to call the corresponding constructor, if the list is empty, it will call the other constructor
                    {
                        Reference reference = new Reference(book, chapter, verses); // calls the multiple verses constructor
                        references.Add(reference); // adds the reference to the list
                    }
                    else
                    {
                        Reference reference = new Reference(book, chapter, verse); // calls the single verse constructor
                        references.Add(reference); // adds the reference to the list 
                    }

                    string[] textString = text.Split(" "); // split the text using spaces and creates for each word a word object
                    foreach (string w in textString)
                    {
                        Word word = new Word(w);
                        words.Add(word); // adds each word to a list of words
                    }

                    listOfWords.Add(words); // adds each list of words to a list of lists of words
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred");
            Console.WriteLine(e.Message);
        }

        for (int i = 0; i < references.Count; i++) // this will add each scripture to a list of scriptures
        {
            Scripture scripture = new Scripture(references[i], listOfWords[i]);
            scriptures.Add(scripture);
        }

        return scriptures; // return the list of scriptures
    }
    static Scripture Menu() // this is a menu for the user to pick a scripture to memorize
    {
        Console.WriteLine("What scripture would you like to memorize?");
        List<Scripture> scriptures = new List<Scripture>(); // an empty list of scriptures
        scriptures = GetListOfScripture(); // the list of scriptures will be filled with the scriptures from the file
        int i = 1;
        foreach (Scripture scripture in scriptures) // displays each scripture reference for the user to pick one
        {
            if (scripture._reference._verses != null) // if the scripture has more than one verse
            {
                Reference reference = new Reference(scripture._reference._book, scripture._reference._chapter, scripture._reference._verses);
                Console.Write($"{i}. ");
                reference.DisplayReference();
                Console.WriteLine();
            }
            else // if the scripture has just one verse
            {
                Reference reference = new Reference(scripture._reference._book, scripture._reference._chapter, scripture._reference._verse);
                Console.Write($"{i}. ");
                reference.DisplayReference();
                Console.WriteLine();
            }
            i++;
        }
        int n = int.Parse(Console.ReadLine()); // gets the user input as an integer
        Scripture s = new Scripture(scriptures[n-1]._reference, scriptures[n-1]._text); // gets the user input as an index for the list of scriptures
        return s; // returns the scripture chosen by the user
    }
}