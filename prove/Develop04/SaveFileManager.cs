using System;
using System.Collections.Generic;
using System.IO;

public class SaveFileManager
{
    private string _fileName { get; set; }
    private string _filePath { get; set; }
    private string _folderPath { get; set; }

    public SaveFileManager()
    {
    }
    
    public SaveFileManager(string fileName, string filePath, string folderPath)
    {
        _fileName = fileName;
        _filePath = filePath;
        _folderPath = folderPath;
    }

    public void CreateFolder(string folderPath)
    {
        if (Directory.Exists(folderPath))
        {
            Console.WriteLine();
        }
        else
        {
            // If the folder doesn't exist, create it
            Directory.CreateDirectory(folderPath);
        }
    }

    public List<string> EnumerateFiles(string path)
    {
        List<string> filesList = new List<string>();
        var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
        Console.WriteLine("FILES:");
        foreach (string s in files) 
        {
            Console.WriteLine(s);
            filesList.Add(s);
        }
        return filesList;
    }

    public SaveFile ReadFile(string path)
    {
        List<SaveFile> activities = new List<SaveFile>();
        
        int numberOfActivities = 0;
        try 
        {
            using (StreamReader sr = File.OpenText(path)) 
            {
                while (!sr.EndOfStream) 
                {
                    string line = sr.ReadLine();
                    string[] information = line.Split(",");
                    string dateString = information[0];
                    string activityName = information[1];
                    numberOfActivities ++;
                    DateTime date = DateTime.Parse(dateString);
                    SaveFile activity = new SaveFile(date, activityName);
                    activities.Add(activity);
                }
                
            }
        }
        catch (IOException e) 
        {
            Console.WriteLine("An error occurred");
            Console.WriteLine(e.Message);
        }
        SaveFile saveFile = new SaveFile(activities, numberOfActivities);
        return saveFile;
    }

    public void SaveNewFile(SaveFile saveFile)
    {
        List<SaveFile> saveFiles = saveFile._activities;
        
        File.Create(@$"{_filePath}\{_fileName}");
        try 
        {
            using (StreamWriter sw = File.AppendText(_filePath)) 
            {
                for (int i = 0; i < saveFiles.Count; i++)
                {
                    DateTime date = saveFiles[i]._date;
                    string activityName = saveFiles[i]._activityName;
                    sw.WriteLine($"{date.ToString("dd/MM/yyyy HH:mm:ss")},{activityName}");
                }
            }
        } 
        catch (IOException e) 
        {
            Console.WriteLine("An error occurred");
            Console.WriteLine(e.Message);
        }
    }

    public void DeleteFile(string path, string fileName)
    {
        List<string> filesList = new List<string>();
        var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
        foreach (string s in files)
        {
            filesList.Add(s);
        }
        for (int i = 0; i < filesList.Count; i++)
        {
            if (filesList[i] == fileName)
            {
                File.Delete(filesList[i]);
            }
        }
    }
}