public abstract class Goal
{
    public string _name { get; protected set; }
    protected string _description { get; set; }
    public int _points { get; protected set; }
    public bool _isComplete { get; protected set; }
    
    public Goal(string name, string description, int points) // Class constructor
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false; // Sets the _isComplete as false when created
    }

    public virtual void RecordEvent() // Records when a goal is completed
    {
        Console.WriteLine($"Congratulations! You have earned {_points} points!");
        _isComplete = true; // Sets the _isComplete attribute to true
    }

    public virtual bool IsComplete() // Returns a true boolean value
    {
        return true;
    }

    public virtual string GetDetailString() // Returns a string representation of the task
    {
            if (_isComplete == true) // If completed a 'x' is going to be placed inside the square brackets []
            {
                return "[x] " 
                    + _name
                    + " ("
                    + _description
                    + ")";
            }
            else // If not completed, the square brackets are empty
            {
                return "[ ] " 
                    + _name
                    + " ("
                    + _description
                    + ")";
            } 
    }

    public abstract string GetStringRepresentation(); // Abstract method to be implemented in each sub-class
}