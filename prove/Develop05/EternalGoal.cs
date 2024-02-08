public class EternalGoal : Goal // EternalGoal class inherits from Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) // Class constructor with the base class constructor as base
    {
    }

    public override void RecordEvent() // This overrides the RecordEvent method so this type of goal is never really completed
    {
        Console.WriteLine($"Congratulations! You have earned {_points} points!");
    }

    public override string GetStringRepresentation() // GetStringRepresentation abstract method from the base class overriden for this class
    {
        return "EternalGoal;"
            + $"{_name};"
            + $"{_description};"
            + $"{_points}";
    }
}