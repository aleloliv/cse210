public class BreathingActivity : Activity
{
    public BreathingActivity() : base()
    {
        _activityName = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
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
        for (int i = 0; i < _duration / 10; i++)
        {
            Console.Write("Breath in...");
            Console.WriteLine();
            CountDown(4);
            Console.Write("Breath out...");
            Console.WriteLine();
            CountDown(6);
        }
        End();
    }
}