using System;
using System.Diagnostics;
using System.Dynamic;
using System.Threading;

public abstract class Activity // An abstract class that serves as a base class Activity
{
    public string _activityName { get; protected set; } // This is the activity name paramether, in order for it to be saved into a file, it needs to be public put the setter protected for anything that is not a sub-class
    protected string _description { get; set; } // Protected attribute description
    protected int _duration { get; set; } // Protected attribute duration of the activity
    protected DateTime _start { get; set; } // Protected attribute date of start of activity
    protected DateTime _end { get; set; } // // Protected attribute date of end of activity

    public Activity() // Empty constructor
    {
    }

    public void Start() // This method starts the activity with a greatings message
    {
        Console.Clear(); // Clears the console
        Console.WriteLine($"Welcome to the {_activityName}.\n"); // This will display the welcome message using the name of the activity declared on the specific constructor
        Console.WriteLine(_description); // This will display the description specified in the constructor
        Console.Write("\nHow long, in seconds, would you like for your sesstion? "); // This will ask for the user how long they want the activity to last
        int duration = int.Parse(Console.ReadLine());
        _duration = duration; // Get the user input and stores it into the duration as a constructor
        Console.WriteLine("\nPrepare to begin...");
        Pause(5); // Calls the Pause method with 5 seconds as paramether
        Console.WriteLine(); // Skips a line
        _start = DateTime.Now; // Stores the now date in the _start attribute
        ActivityMoment(); // Calls the ActivityMoment method, specified in the sub-class
    }

    public abstract void ActivityMoment(); // Sets the ActivityMoment method as an abstract method that needs to be implemented in each sub-class

    public void Pause(int duration) // This will get a duration in secods as a paramether and pause the program for that duration while displaying an animation ...
    {
        Stopwatch stopwatch = new Stopwatch(); // Calls the stopwatch namespace from System.Diagnostics
        stopwatch.Start(); // Starts the stopwatch

        while (stopwatch.Elapsed.TotalSeconds < duration) // This will happen while the duration in seconds is not met
        {
            Thread.Sleep(250); // Stops the thread and the application for 250 milliseconds or 1/4 of a second

            Console.Write("."); // Displays a dot (".")
            
            Thread.Sleep(250); // Stops the thread and the application for 250 milliseconds or 1/4 of a second 

            Console.Write("."); // Displays a dot (".")

            Thread.Sleep(250); // Stops the thread and the application for 250 milliseconds or 1/4 of a second

            Console.Write("."); // Displays a dot (".")

            Thread.Sleep(250); // Stops the thread and the application for 250 milliseconds or 1/4 of a second

            Console.Write("\b \b"); // Erases the last printed dot (".")

            Console.Write("\b \b"); // Erases the second printed dot (".")

            Console.Write("\b \b"); // Erases the first printed dot (".")
        }
        stopwatch.Stop();
    }

    public void CountDown(int duration) // This method pauses the application for a specific amount of seconds while displaying a count down
    {
        for (int i = 0; i < duration; i++) // Starts a loop with an int i variable as 0
        {
            Console.Write($"{duration - i}"); // This will get the amount of seconds and print it minus the int i variable each time

            Thread.Sleep(500); // Stops the thread and the application for 500 milliseconds or 1/2 of a second

            Console.Write("\b \b"); // Erases the number printed to the screen

            Thread.Sleep(500); // Stops the thread and the application for 500 milliseconds or 1/2 of a second
        }
    }

    public void End() // This will display the ending message and the name of the activity and how much time it lasted
    {
        _end = DateTime.Now; // Registers the time at the end of the activity
        Console.WriteLine("\nCongratulations! You have done a great job!"); // Displays the congratulations message
        TimeSpan duration = _end.Subtract(_start); // Gets a TimeSpan object subtracting the start date from the end date
        Console.WriteLine($"\nYou completed another {_activityName} in {duration.TotalSeconds.ToString("F0")} seconds!"); // Displays the final message with the activity name specified by the constructor and the total amount of seconds that the activity lasted
        Pause(5); // Calls the Pause method with 5 seconds as paramether
    }
}