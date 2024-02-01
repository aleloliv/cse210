using System;
using System.Collections.Generic;
using System.IO;

public class SaveFile // This is meant to store the information in a file
{
    public DateTime _date { get; private set; } // The date of the activity
    public string _activityName { get; private set; } // The name of the activity
    public List<SaveFile> _activities { get; private set; } // A list of activities
    public int _numberOfActivities { get; private set; } // How many activities were done
    

    public SaveFile(List<SaveFile> activities, int numberOfActivities) // This is one of the override constructors, this receives a list of SaveFile objects and the number of activities
    {
        _activities = activities; // Gets the list of activities
        _numberOfActivities = numberOfActivities; // Gets the number of activities
    }

    public SaveFile(DateTime date, string activityName) // This is the other constructor receiving the date and the name of the activity
    {
        _date = date; // Gets the date
        _activityName = activityName; // Gets the name of the activity
    }

    public void PrintFile() // This method is supposed to print the information of the SaveFile
    {
        List<SaveFile> listOfSave = _activities; // Initiates the list of activities with the attribute _activities from the constructor
        for (int i = 0; i < listOfSave.Count; i++) // This will happen until the end fo the list
        {
            Console.WriteLine($"{listOfSave[i]._date.ToString("dd/MM/yyyy HH:mm:ss")},{listOfSave[i]._activityName}"); // Prints the date of the activity than the name
        }
    }
}