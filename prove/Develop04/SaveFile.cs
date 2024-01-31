using System;
using System.Collections.Generic;
using System.IO;

public class SaveFile
{
    public DateTime _date { get; private set; }
    public string _activityName { get; private set; }
    public List<SaveFile> _activities { get; private set; }
    public int _numberOfActivities { get; private set; }
    

    public SaveFile(List<SaveFile> activities, int numberOfActivities)
    {
        _activities = activities;
        _numberOfActivities = numberOfActivities;
    }

    public SaveFile(DateTime date, string activityName)
    {
        _date = date;
        _activityName = activityName;
    }

    public void PrintFile()
    {
        List<SaveFile> listOfSave = _activities;
        for (int i = 0; i < listOfSave.Count; i++) 
        {
            Console.WriteLine($"{listOfSave[i]._date.ToString("dd/MM/yyyy HH:mm:ss")},{listOfSave[i]._activityName}");
        }
    }
}