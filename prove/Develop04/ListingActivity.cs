using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ListingActivity : Activity
{
    public ListingActivity() : base ()
    {
        _activityName = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public string GetPrompt()
    {
        Random random = new Random();

        List<string> prompts = new List<string>();

        string prompt1 = "Who are people that you appreciate?";
        string prompt2 = "What are personal strengths of yours?";
        string prompt3 = "Who are people that you have helped this week?";
        string prompt4 = "When have you felt the Holy Ghost this month?";
        string prompt5 = "Who are some of your personal heroes?";

        prompts.Add(prompt1);
        prompts.Add(prompt2);
        prompts.Add(prompt3);
        prompts.Add(prompt4);
        prompts.Add(prompt5);

        int num = random.Next(0, prompts.Count - 1);

        return prompts[num];
    }

    public void CountDown(int duration)
    {
        for (int i = 0; i < duration; i++)
        {
            Console.Write($"{duration - i}");

            Thread.Sleep(500);

            Console.Write("\b \b");

            Thread.Sleep(500);
        }
    }
    public override void ActivityMoment()
    {
        List<string> list = new List<string>();

        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine(GetPrompt());
        Console.Write("You may begin in: ");
        CountDown(5);
        Console.WriteLine();
        
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds < _duration - 5)
        {
            Console.Write("> ");
            list.Add(Console.ReadLine());
        }
        
        stopwatch.Stop();

        Console.WriteLine($"You listed {list.Count} items.");
        
        End();
    }
}