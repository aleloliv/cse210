public class BreathingActivity : Activity // BreathingActivity inherits from Activity class
{
    public BreathingActivity() : base() // This constructor uses the base blank constructor as a base, this was meant to implement other functionalities but it is actually not necessary in this code
    {
        _activityName = "Breathing Activity"; // Sets the name of the activity as Breathing Activity
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."; // Sets the description
    }

    public override void ActivityMoment() // This overrides or overwrhrites the ActivityMoment method from the super-class
    {
        for (int i = 0; i < _duration / 10; i++) // This loop gets the duration and divides it by ten because each loop lasts for 10 seconds
        {
            Console.Write("Breath in..."); // Prints the first message
            CountDown(4); // Calls the super-class method for 4 seconds
            Console.WriteLine(); // Skips a line
            Console.Write("Breath out..."); // // Prints the second message
            CountDown(6); // Calls the super-class method for 6 seconds
            Console.WriteLine(); // Skips a line
        }
        
        End(); // Calls the End method from the super-class
    }
}