using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ReflectionActivity : Activity // The ReflectionActivity inherist from the Activity class
{
    public ReflectionActivity() : base() // This constructor uses the base blank constructor as a base, this was meant to implement other functionalities but it is actually not necessary in this code
    {
        _activityName = "Reflection Activity"; // Sets the name of the activity as Reflection Activity
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."; // Sets the description
    }
    public override void ActivityMoment() // This overrides or overwrhrites the ActivityMoment method from the super-class
    {
        Stopwatch stopwatch = new Stopwatch(); // Calls the stopwatch namespace from System.Diagnostics
        stopwatch.Start(); // Starts the stopwatch

        while (stopwatch.Elapsed.TotalSeconds < _duration) // While the time specified by the user is not reached this will repeat
        {
            Console.WriteLine(GetPrompt()); // Calls the GetPrompt method from this class
            Pause(5); // Calls the Pause method from the super-class
            Console.WriteLine(GetReflection()); // Calls the GetReflection method from this class
            Pause(5); // Calls the Pause method from the super-class
        }

        stopwatch.Stop(); // Stops the stopwatch

        End(); // Calls the End method from the super-class
    }

    public string GetPrompt() // This picks a random prompt from a list
    {
        List<string> prompts = new List<string>() // Starts the list with the prompts
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        
        Random random = new Random(); // Gets a random object

        int num = random.Next(0, prompts.Count - 1); // Gets a random number ranging from 0 to the number of prompts - 1 as an index

        return prompts[num]; // Returns the prompt at the random number index from the list
    }

    public string GetReflection() // This picks a random reflection from a list
    {
        List<string> prompts = new List<string>() // Starts the list with the reflections
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        Random random = new Random(); // Gets a random object

        int num = random.Next(0, prompts.Count - 1); // Gets a random number ranging from 0 to the number of reflections - 1 as an index

        return prompts[num]; // Returns the reflection at the random number index from the list
    }
}