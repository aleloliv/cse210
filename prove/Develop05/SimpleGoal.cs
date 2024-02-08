public class SimpleGoal : Goal // SimpleGoal class inherits from Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points) // Class constructor with the base class constructor as base
    {
    }

    public override string GetStringRepresentation() // GetStringRepresentation abstract method from the base class overriden for this class
    {
        return "SimpleGoal;"
            + $"{_name};"
            + $"{_description};"
            + $"{_points};"
            + $"{_isComplete}";
    }
}