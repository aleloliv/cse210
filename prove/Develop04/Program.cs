using System;
using System.Collections.Generic;
using System.IO;

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
                if (!int.TryParse(Console.ReadLine(), out selection))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue; // Skip the rest of the loop and ask for input again
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
                        return;
                    default:
                        Console.WriteLine("Please select 1, 2, 3, or 4");
                        continue; // Skip the rest of the loop and ask for input again
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
                    + "\n3. Save progress"
                    + "\n4. Create a new save file"
                    + "\n5. Delete a file"
                    + "\n6. Quit");
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
                        saveFileManager.LoadSaveFile(folderPath);
                        break;
                    case 3:
                        saveFileManager.SaveProgress(folderPath);
                        break;
                    case 4:
                        saveFileManager.CreateNewSaveFile(folderPath);
                        break;
                    case 5:
                        saveFileManager.DeleteFile(folderPath);
                        break;
                    case 6:
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
        try
        {
            string folderPath = @"log-files";
            SaveFileManager saveFileManager = new SaveFileManager("temp.txt", folderPath, folderPath);

            DateTime now = DateTime.Now;
            SaveFile newSaveLine = new SaveFile(now, activity._activityName);
            List<SaveFile> saveLines = new List<SaveFile> { newSaveLine };
            SaveFile newSave = new SaveFile(saveLines, saveLines.Count);
            
            saveFileManager.SaveNewFile(newSave);
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }
}