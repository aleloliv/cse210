using System;
using System.Diagnostics;
using System.Dynamic;
using System.Threading;

public abstract class Activity
{
    public string _activityName { get; protected set; }
    protected string _description { get; set; }
    protected int _duration { get; set; }
    protected DateTime _start { get; set; }
    protected DateTime _end { get; set; }
    protected int _pauses { get; set; }

    public Activity()
    {
        _pauses = 0;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your sesstion? ");
        int duration = int.Parse(Console.ReadLine());
        _duration = duration;
        Console.WriteLine("\nPrepare to begin...");
        Pause(5);
        Console.WriteLine();
        _start = DateTime.Now;
        ActivityMoment();
    }

    public abstract void ActivityMoment();

    public void Pause(int duration)
    {
        _pauses += 1;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds < duration)
        {
            Thread.Sleep(250);

            Console.Write(".");
            
            Thread.Sleep(250);

            Console.Write(".");

            Thread.Sleep(250);

            Console.Write(".");

            Thread.Sleep(250);

            Console.Write("\b \b");

            Console.Write("\b \b");

            Console.Write("\b \b");
        }
        stopwatch.Stop();
    }

    public void End()
    {
        _end = DateTime.Now;
        Console.WriteLine("\nCongratulations! You have done a great job!");
        TimeSpan duration = _end.Subtract(_start);
        Console.WriteLine($"\nYou completed another {_activityName} in {duration.TotalSeconds.ToString("F0")} seconds!");
        Pause(5);
    }
}