using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ReflectionActivity : Activity
{
    public ReflectionActivity() : base()
    {
        _activityName = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }
    public override void ActivityMoment()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds < _duration)
        {
            Console.WriteLine(GetPrompt());
            Pause(5);
            Console.WriteLine(GetReflection());
            Pause(5);
        }

        stopwatch.Stop();

        End();
    }

    public string GetPrompt()
    {
        List<string> prompts = new List<string>();

        string prompt1 = "Think of a time when you stood up for someone else.";
        string prompt2 = "Think of a time when you did something really difficult.";
        string prompt3 = "Think of a time when you helped someone in need.";
        string prompt4 = "Think of a time when you did something truly selfless.";

        prompts.Add(prompt1);
        prompts.Add(prompt2);
        prompts.Add(prompt3);
        prompts.Add(prompt4);

        Random random = new Random();

        int num = random.Next(0, prompts.Count - 1);

        return prompts[num];
    }

    public string GetReflection()
    {
        List<string> prompts = new List<string>();

        string reflection1 = "Why was this experience meaningful to you?";
        string reflection2 = "Have you ever done anything like this before?";
        string reflection3 = "How did you get started?";
        string reflection4 = "How did you feel when it was complete?";
        string reflection5 = "What made this time different than other times when you were not as successful?";
        string reflection6 = "What is your favorite thing about this experience?";
        string reflection7 = "What could you learn from this experience that applies to other situations?";
        string reflection8 = "What did you learn about yourself through this experience?";
        string reflection9 = "How can you keep this experience in mind in the future?";

        prompts.Add(reflection1);
        prompts.Add(reflection2);
        prompts.Add(reflection3);
        prompts.Add(reflection4);
        prompts.Add(reflection5);
        prompts.Add(reflection6);
        prompts.Add(reflection7);
        prompts.Add(reflection8);
        prompts.Add(reflection9);

        Random random = new Random();

        int num = random.Next(0, prompts.Count - 1);

        return prompts[num];
    }
}