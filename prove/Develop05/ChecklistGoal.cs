public class ChecklistGoal : Goal // ChecklistGoal class inherits from Goal
{
    private int _amountCompleted { get; set; } // The amount of times this goal has been completed
    private int _target { get; set; } // The target amount of times to complete this goal
    public int _bonus { get; private set; } // The amount of bonus points

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points) // Class constructor with the base class constructor as base
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override string GetDetailString() // This overrides the GetDetailString method from the base class adding to the text the string with the _amountCompleted and _target attributes
    {
        return base.GetDetailString() + $"-- Currenly completed: {_amountCompleted}/{_target}";
    }

    public override void RecordEvent() // This overrides the RecordEvent method so it will only give the bonus points and register as complete when the _amountCompleted and _target attributes match
    {
        Console.WriteLine($"Congratulations! You have earned {_points} points!");
        _amountCompleted++;
        if (_amountCompleted == _target)
        {
            Console.WriteLine($"Congratulations! You have finished {_name}! For this you will be awarded {_bonus} bonus points!");
            _isComplete = IsComplete();
        }
    }

    public override string GetStringRepresentation() // GetStringRepresentation abstract method from the base class overriden for this class
    {
        return "ChecklistGoal;"
            + $"{_name};"
            + $"{_description};"
            + $"{_points};"
            + $"{_bonus};"
            + $"{_target};"
            + $"{_amountCompleted}";
    }

}