using System;
using System.Collections.Generic;
using System.IO;

// SaveFileManager class for managing file-related operations
public class SaveFileManager
{
    // Properties for file information
    public string _fileName { get; private set; }
    private string _filePath { get; set; }
    private string _folderPath { get; set; }

    // Default constructor
    public SaveFileManager() { }

    // Parameterized constructor to initialize file information
    public SaveFileManager(string fileName, string filePath, string folderPath)
    {
        _fileName = fileName;
        _filePath = filePath;
        _folderPath = folderPath;
    }

    // Method to create a folder if it doesn't exist
    public void CreateFolder(string folderPath)
    {
        try
        {
            if (Directory.Exists(folderPath))
            {
                Console.WriteLine($"Folder '{folderPath}' already exists.");
            }
            else
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine($"Folder '{folderPath}' created successfully.");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while creating the folder: {e.Message}");
        }
    }

    // Method to enumerate files in a directory, excluding specific files
    public List<string> EnumerateFiles(string path)
    {
        List<string> filesList = new List<string>();

        try
        {
            var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);

            foreach (string filePath in files)
            {
                filesList.Add(filePath);
            }

            if (filesList.Count == 0)
            {
                Console.WriteLine("No files to load");
                return null;
            }
            else
            {
                // Exclude specific files from the list
                filesList.RemoveAll(file => Path.GetFileName(file) == "file-info.txt" || Path.GetFileName(file) == "temp.txt");

                Console.WriteLine("FILES:");
                foreach (string fileName in filesList)
                {
                    Console.WriteLine(Path.GetFileName(fileName));
                }

                return filesList;
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while enumerating files: {e}");
            return null;
        }
    }

    // Method to read a file and return SaveFile object
    public SaveFile ReadFile(string path)
    {
        List<SaveFile> activities = new List<SaveFile>();
        int numberOfActivities = 0;

        try
        {
            // Use Path.Combine to concatenate paths for better reliability
            string filePath = Path.Combine(path);

            // Using statement for StreamReader to ensure proper resource disposal
            using (StreamReader sr = File.OpenText(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] information = line.Split(",");
                    if (information.Length >= 2) // Ensure array has at least two elements
                    {
                        string dateString = information[0];
                        string activityName = information[1];
                        numberOfActivities++;
                        DateTime date = DateTime.Parse(dateString);
                        SaveFile activity = new SaveFile(date, activityName);
                        activities.Add(activity);
                    }
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while reading the file: {e}");
        }

        SaveFile saveFile = new SaveFile(activities, numberOfActivities);
        return saveFile;
    }

    // Method to save a new file
    public void SaveNewFile(SaveFile saveFile)
    {
        List<SaveFile> saveFiles = saveFile._activities;

        try
        {
            // Use Path.Combine to concatenate paths for better reliability
            string filePath = Path.Combine(_filePath, _fileName);

            // Using statement for StreamWriter to ensure proper resource disposal
            using (StreamWriter sw = File.AppendText(filePath))
            {
                foreach (SaveFile entry in saveFiles)
                {
                    DateTime date = entry._date;
                    string activityName = entry._activityName;
                    sw.WriteLine($"{date.ToString("dd/MM/yyyy HH:mm:ss")},{activityName}");
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while saving the file: {e}");
        }
    }

    // Method to delete a file
    public void DeleteFile(string path)
    {
        List<string> files = EnumerateFiles(_filePath);
        foreach (string s in files)
        {
            Console.WriteLine(s);
        }
        Console.Write("What is the file name? ");
        string fileName = Console.ReadLine();
        try
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(fileName))
            {
                Console.WriteLine("Invalid path or filename.");
                return;
            }

            string filePath = Path.Combine(path, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine($"File '{fileName}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"File '{fileName}' does not exist at the specified path {filePath}.");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while deleting the file: {e}");
        }
    }

    // Method to erase the content of a file
    public void EraseFileContent(string path, string fileName)
    {
        try
        {
            // Use Path.Combine to concatenate paths for better reliability
            string filePath = Path.Combine(path, fileName);

            // Open the file for writing, which will erase its content
            using (StreamWriter sw = File.CreateText(filePath))
            {
                // No need to read content, just create an empty file
            }
        }
        catch (IOException e)
        {
            // Log the exception details
            Console.WriteLine($"An error occurred while erasing file content: {e}");
        }
    }

    // Method to store information about a file
    public void StoreFileInfo(string fileName)
    {
        try
        {
            string filePath = Path.Combine("log-files", "file-info.txt");

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"File,{fileName}");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while storing file information: {e}");
        }
    }

    // Method to set the current file information
    public SaveFileManager SetCurrentFile(string fileName, string filePath, string folderPath)
    {
        try
        {
            using (StreamReader sr = File.OpenText(@$"{filePath}\{fileName}"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] information = line.Split(",");
                    if (information[0] == "File," && information.Length > 1)
                    {
                        fileName = information[1];
                        break;
                    }
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while setting current file: {e}");
        }

        SaveFileManager saveFileManager = new SaveFileManager(fileName, "log-files", "log-files");

        return saveFileManager;
    }

    // Method to load a save file
    public void LoadSaveFile(string folderPath)
    {
        List<string> files = EnumerateFiles(folderPath);
        Console.Write("\nSelect a file from the list: ");
        string file = Console.ReadLine();
        if (File.Exists(Path.Combine(folderPath, file)))
        {
            StoreFileInfo(file);
        }
        else
        {
            Console.WriteLine($"This file {file} doesn't exist.");
        }
    }

    // Method to save progress into the loaded save file
    public void SaveProgress(string folderPath)
    {
        try
        {
            List<string> checkFiles = EnumerateFiles(folderPath);
            if (checkFiles == null)
            {
                return;
            }
            SaveFileManager currentFileManager = SetCurrentFile("file-info.txt", "log-files", "log-files");
            string fileName = currentFileManager._fileName;
            SaveFile currentSave = currentFileManager.ReadFile(Path.Combine(folderPath, "temp.txt"));
            List<SaveFile> activities = currentSave._activities;
            int numberOfActivities = currentSave._numberOfActivities;
            for (int i = 0; i < activities.Count; i++)
            {
                using (StreamWriter sw = File.AppendText(Path.Combine(folderPath, fileName)))
                {
                    sw.WriteLine($"{activities[i]._date.ToString("dd/MM/yyyy HH:mm:ss")},{activities[i]._activityName}");
                }
            }
            currentFileManager.EraseFileContent(folderPath, "file-info.txt");
            EraseFileContent(folderPath, "temp.txt");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while saving progress: {e}");
        }
    }

    // Method to create a new save file
    public void CreateNewSaveFile(string folderPath)
    {
        Console.Write("What is the name of the new save file? (DO NOT type the format type) ");
        string fileName = Console.ReadLine();
        SaveFileManager saveNewFiles = new SaveFileManager($"{fileName}.txt", folderPath, folderPath);
        SaveFile newSaveFile = ReadFile(Path.Combine(folderPath, "temp.txt"));
        saveNewFiles.SaveNewFile(newSaveFile);
        EraseFileContent(folderPath, "temp.txt");
    }
}