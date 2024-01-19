using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public Journal(List<Entry> entries)
    {
        _entries = entries;
    }

    public void AddEntry(Entry entry)
    {
         _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter sw = File.AppendText(filename))
            {
                foreach (Entry entry in _entries)
                {
                    DateTime date = entry._date;
                    string prompt = entry._promptText;
                    string entryText = entry._entryText;
                    string writtenEntry = $"{date.ToString("yyyy-MM-dd HH:mm:ss")},{prompt},{entryText}";
                    sw.WriteLine(writtenEntry);
                }
            }
        }
        catch (IOException e){
            Console.WriteLine("An error occurred");
            Console.WriteLine(e.Message);
        }
    }
    public void LoadFromFile(string filename)
    {
        try
        {
            using (StreamReader sr = File.OpenText(filename))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] lines = line.Split(",");
                    DateTime dateTime = DateTime.Parse(lines[0]);
                    string promptText = lines[1];
                    string entryText = lines[2];
                    Entry entry = new Entry(dateTime, promptText, entryText);
                    _entries.Add(entry);
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred");
            Console.WriteLine(e.Message);
        }
    }
}