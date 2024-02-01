using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ListingActivity : Activity // The ListingActivity inherist from the Activity class
{
    public ListingActivity() : base () // This constructor uses the base blank constructor as a base, this was meant to implement other functionalities but it is actually not necessary in this code
    {
        _activityName = "Listing Activity"; // Sets the name of the activity as Reflection Activity
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."; // Sets the description
    }

    public string GetPrompt() // This picks a random prompt from a list
    {
        Random random = new Random(); // Gets a random object

        List<string> prompts = new List<string>() // Starts the list with the prompts
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        int num = random.Next(0, prompts.Count - 1); // Gets a random number ranging from 0 to the number of prompts - 1 as an index

        return prompts[num]; // Returns the prompt at the random number index from the list
    }

    public override void ActivityMoment() // This overrides or overwrhrites the ActivityMoment method from the super-class
    {
        List<string> list = new List<string>(); // Starts an empty list

        Console.WriteLine("\nList as many responses you can to the following prompt:"); // Tells the user to write as many items as they can
        Console.WriteLine(GetPrompt()); // Writes the prompt that is returned from the GetPrompt method from this class
        Console.Write("You may begin in: "); // Tells the user they can begin soon
        CountDown(5); // Calls the super-class method
        Console.WriteLine(); // Skips a line
        
        Stopwatch stopwatch = new Stopwatch(); // Calls the stopwatch namespace from System.Diagnostics
        stopwatch.Start(); // Starts the stopwatch

        while (stopwatch.Elapsed.TotalSeconds < _duration - 5) // While the time specified by the user is not reached this will repeat. This is subtracting 5 seconds from the duration because the initial message takes that much time
        {
            Console.Write("> "); // prints a ">" character to indicate the user must write
            list.Add(Console.ReadLine()); // Adds the user input to the list
        }
        
        stopwatch.Stop(); // Stops the stopwatch

        Console.WriteLine($"You listed {list.Count} items."); // Counts how many items are in the list and tells the user how many they have wrote
        
        End(); // Calls the super-class method End
    }
}