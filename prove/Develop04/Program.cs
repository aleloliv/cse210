using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        LogFile();
    }

    static void Menu()
    {
        try
        {
            bool playAgain = false;

            do
            {
                Console.WriteLine("Menu Options:"
                    + "\n   1. Start breathing activity"
                    + "\n   2. Start reflection activity"
                    + "\n   3. Start listing activity"
                    + "\n   4. Quit");

                Console.Write("Select a choice from the menu: ");

                int selection;
                while (!int.TryParse(Console.ReadLine(), out selection))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Activity activity;

                switch (selection)
                {
                    case 1:
                        activity = new BreathingActivity();
                        SaveNow(activity);
                        break;
                    case 2:
                        activity = new ReflectionActivity();
                        SaveNow(activity);
                        break;
                    case 3:
                        activity = new ListingActivity();
                        SaveNow(activity);
                        break;
                    case 4:
                        return; // Quit the program.
                    default:
                        Console.WriteLine("Please select 1, 2, or 3");
                        continue; // Go back to the menu if the input is invalid.
                }

                activity.Start();
                playAgain = PlayAgain();

            } while (playAgain);
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }

    static bool PlayAgain()
    {
        while (true)
        {
            try
            {
                Console.Write("\nWould you like to continue? (Y/N): ");
                string response = Console.ReadLine();

                if (response.ToUpper() == "Y")
                {
                    return true;
                }
                else if (response.ToUpper() == "N")
                {
                    return false;
                }
                else
                {
                    Console.Write("You must choose Y or N");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR!");
                Console.WriteLine(e.Message);
            }
        }
    }

    static void LogFile()
    {
        try
        {
            SaveFileManager saveFileManager = new SaveFileManager();
            string folderPath = @"log-files";
            saveFileManager.CreateFolder(folderPath);

            do
            {
                Console.WriteLine("Welcome to the Mindfulness Activity program!"
                    + "\nWhat would you like to do?"
                    + "\n1. Go to Activities"
                    + "\n2. Select a save file to load"
                    + "\n3. Create a new save file"
                    + "\n4. Delete a file"
                    + "\n5. Quit");
                Console.WriteLine();

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                switch (choice)
                {
                    case 1:
                        Menu();
                        break;
                    case 2:
                        List<string> files = saveFileManager.EnumerateFiles(folderPath);
                        Console.WriteLine("\nSelect a file from the list: ");
                        string file = Console.ReadLine();
                        SaveFile saveFile = saveFileManager.ReadFile(@$"{folderPath}\{file}");
                        saveFile.PrintFile();
                        break;
                    case 3:
                        Console.Write("What is the name of the new save file? (DO NOT type the format type) ");
                        string fileName = Console.ReadLine();
                        SaveFileManager saveNewFiles = new SaveFileManager(@$"{fileName}.txt", @$"log-files", @"log-files");
                        SaveFile newSaveFile = saveFileManager.ReadFile(@$"{folderPath}\temp.txt");
                        saveNewFiles.SaveNewFile(newSaveFile);
                        break;
                    case 4:
                        List<string> filesDelete = saveFileManager.EnumerateFiles(folderPath);
                        Console.WriteLine("\nSelect a file from the list: ");
                        string fileToDelete = Console.ReadLine();
                        string filePath = @$"{folderPath}\{fileToDelete}";
                        Console.Write($"This file {fileToDelete} will be deleted, are you sure? (Y/N) ");
                        string delete = Console.ReadLine();
                        if (delete.ToUpper() == "Y")
                        {
                            saveFileManager.DeleteFile(filePath, fileToDelete);
                        }
                        break;
                    case 5:
                        return;
                    default:
                        Console.Write("Select a valid option: ");
                        break;
                }
            } while (true);
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }

    static void SaveNow(Activity activity)
    {
        string fileName = "temp.txt";
        SaveFileManager saveFileManager = new SaveFileManager(fileName, @"log-files", @"\Develop04");
        DateTime now = DateTime.Now;
        SaveFile newSave = new SaveFile(now, activity._activityName);
        saveFileManager.SaveNewFile(newSave);
    }
}