using System;
using System.Runtime.CompilerServices;

//EXCEEDING REQUIREMENTS: Add a method to delete a goal from the list of goals created by the user.

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>(); // Creates an empty list of Goal objects
        GoalManager goalManager = new GoalManager(goals, 0); // Creates a new GoalManager object
        goalManager.Start(); // Calls the Start method from the GoalManager class
    }
}