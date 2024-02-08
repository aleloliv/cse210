using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    public List<Goal> _goals { get; set; } // Creates a list of Goal objects
    public int _score { get; set; } // The user's score

    public GoalManager(List<Goal> goals, int score) // Class constructor
    {
        _goals = goals;
        _score = score;
    }

    public void Start() // This is the starting menu, with all the main actions from the program
    {
        try
        {
            while (true)
            {
                Console.WriteLine(); // Blank line
                DisplayPlayerInfo(); // Calls the DisplayPlayerInfor method from this class
                Console.WriteLine(); // Blank line
                Console.WriteLine("Menu options: " // Main Menu
                                + "\n   1. Create New Goal"
                                + "\n   2. List Goals"
                                + "\n   3. Save Goals"
                                + "\n   4. Load Goals"
                                + "\n   5. Delete Goal"
                                + "\n   6. Record Event"
                                + "\n   7. Quit");
                Console.Write("Select a choice from the menu: ");
                if (!int.TryParse(Console.ReadLine(), out int choice)) // Gets the user input as a number, if the user types anything different, this will repeat
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                Console.WriteLine(); // Blank line

                switch (choice) // Calls a corresponding method for each of the user's choice
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        ListGoals();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        DeleteGoal();
                        break;
                    case 6:
                        RecordEvent();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Please select 1, 2, 3, 4, 5, 6 or 7");
                        break;
                }
            }
        }
        catch (Exception e) // Error handling
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }

    public void DisplayPlayerInfo() // This will display the amount of points the user has
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void CreateGoal() // This method creates a new goal as chosen by the user
    {
        try
        {
            while (true)
            {
                Console.WriteLine("The types of goals are: " // The types of goals available
                        + "\n 1. Simple Goal"
                        + "\n 2. Eternal Goal"
                        + "\n 3. Checklist Goal");
                Console.Write("Which type of goal would you like to create? ");
                if (!int.TryParse(Console.ReadLine(), out int choice)) // Gets the user input as a number, if the user types anything different, this will repeat
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                Goal goal; // Creates a Goal object not instanced

                switch (choice)
                {
                    case 1: // If the user selects a simple goal
                        Console.Write("What is the name of your goal? ");
                        string name1 = Console.ReadLine();
                        Console.Write("What is a short description of it? ");
                        string description1 = Console.ReadLine();
                        Console.Write("What is the amount of points associated with this goal? ");
                        int points1 = int.Parse(Console.ReadLine());
                        goal = new SimpleGoal(name1, description1, points1); // Polymorphs the goal object into a SimpleGoal
                        break;
                    case 2: // If the user selects a eternal goal
                        Console.Write("What is the name of your goal? ");
                        string name2 = Console.ReadLine();
                        Console.Write("What is a short description of it? ");
                        string description2 = Console.ReadLine();
                        Console.Write("What is the amount of points associated with this goal? ");
                        int points2 = int.Parse(Console.ReadLine());
                        goal = new EternalGoal(name2, description2, points2); // Polymorphs the goal object into a EternalGoal
                        break;
                    case 3: // If the user selects a checklist goal
                        Console.Write("What is the name of your goal? ");
                        string name3 = Console.ReadLine();
                        Console.Write("What is a short description of it? ");
                        string description3 = Console.ReadLine();
                        Console.Write("What is the amount of points associated with this goal? ");
                        int points3 = int.Parse(Console.ReadLine());
                        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                        int target3 = int.Parse(Console.ReadLine());
                        Console.Write("What is the bonus for accomplishing it that many times? ");
                        int bonus3 = int.Parse(Console.ReadLine());
                        goal = new ChecklistGoal(name3, description3, points3, target3, bonus3, 0); // Polymorphs the goal object into a ChecklistGoal
                        break;
                    default:
                        Console.WriteLine("Please select 1, 2 or 3");
                        continue;
                }

                _goals.Add(goal); // Adds the object to the list
                break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }
    public void ListGoals() // This prints each goal object in the list in the screen
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailString()}");
        }
    }

    public void SaveGoals() // This opens or creates a file for writing and saves the user info and their goals into a text file
    {
        string folder = "Goals"; // The folder
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine(); // Gets the file name
        try
        {
            if (!Directory.Exists(folder)) // Creates the folder if it doesn't exist
            {
                Directory.CreateDirectory(folder);
                Console.WriteLine($"Folder {folder} created successfully.");
            }

            using (StreamWriter sw = File.CreateText(Path.Combine(folder, fileName))) // Opens or creates the file for writing
            {
                sw.WriteLine(_score); // The first line is the user's score
                foreach (Goal goal in _goals)
                {
                    sw.WriteLine(goal.GetStringRepresentation()); // Calls the GetStringRepresentation from each sub-class according to the object type
                }
            }

            Console.WriteLine("Goals saved successfully."); // Prints in console
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }

    public void LoadGoals() // Load from a file
    {
        _goals.Clear(); // Clear existing goals before loading new ones
        string folder = "Goals"; // The folder
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine(); // Gets the file name from the user
        string filePath = Path.Combine(folder, fileName);
        try
        {
            if (!File.Exists(filePath)) // A safe code, if the file doesn't exist this will tell
            {
                Console.WriteLine($"File '{fileName}' does not exist.");
                return;
            }

            using (StreamReader sr = File.OpenText(filePath)) // Opens the file for reading
            {
                _score = int.Parse(sr.ReadLine()); // Gets the first line as the user's score
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] content = line.Split(';'); // Splits each line using a separator ';'
                    string goalType = content[0]; // The goal type
                    string goalName = content[1]; // The goal name
                    string description = content[2]; // The goal description
                    int points = int.Parse(content[3]); // The points for each goal
                    switch (goalType) // This will select the goal type
                    {
                        case "SimpleGoal":
                            bool isComplete = bool.Parse(content[4]); // Gets the status of the goal, completed or not
                            _goals.Add(new SimpleGoal(goalName, description, points)); // Polymorphs the goal object into a SimpleGoal object
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(goalName, description, points)); // Polymorphs the goal object into a EternalGoal object
                            break;
                        case "ChecklistGoal":
                            int bonus = int.Parse(content[4]); // Gets the bonus amount
                            int target = int.Parse(content[5]); // Gets the target amount of times
                            int amountCompleted = int.Parse(content[6]); // Gets how many times the goal has been completed
                            _goals.Add(new ChecklistGoal(goalName, description, points, target, bonus, amountCompleted)); // Polymorphs the goal object into a ChecklistGoal object
                            break;
                        default:
                            throw new ArgumentException("Unknown goal type");
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully."); // Prints to the screen when finished loading
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR");
            Console.WriteLine(e.Message);
        }
    }

    public void RecordEvent() // This will be called when the user wants to register a completed goal
    {
        try
        {
            while (true)
            {
                Console.WriteLine("The goals are: "); // Calls all the goals from the list
                for (int i = 0; i < _goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_goals[i].GetDetailString()}"); // Calls the GetDetailString from each sub-class depending on the object type
                }
                Console.Write("Which goal did you accomplish? ");
                if (!int.TryParse(Console.ReadLine(), out int choice)) // Gets the user input as a number, if the user types anything different, this will repeat
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                if (choice < 1 || choice > _goals.Count) // This will ensure the number is withing the list index range
                {
                    Console.WriteLine("Invalid choice. Please select a valid goal.");
                    continue;
                }

                Goal selectedGoal = _goals[choice - 1]; // Creates a Goal object using the index from the list and polymorphs it into the specific object type
                selectedGoal.RecordEvent(); // Calls the RecordEvent from each sub-class according to the object type

                if (selectedGoal is ChecklistGoal && selectedGoal._isComplete == true) // This will happen only when the goal is ChecklistGoal and it has been completed
                {
                    int bonus = ((ChecklistGoal)selectedGoal)._bonus; // Gets the bonus amount from the class
                    _score += selectedGoal._points + bonus; // Adds the bonus amount to the standard points
                }
                else // If the goal is not a ChecklistGoal or it is a ChecklistGoal and it has not been completed yet, just adds the amount of points to the score
                {
                    _score += selectedGoal._points;
                }

                DisplayPlayerInfo();
                break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }

    public void DeleteGoal() //EXCEEDING REQUIREMENTS: Deletes a chosen goal
    {
        try
        {
            while (true)
            {
                Console.WriteLine("The goals are: "); // Prints each goal to the screen
                for (int i = 0; i < _goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_goals[i].GetDetailString()}"); // Calls the GetDetailString method from each sub-class according to the object type
                }
                Console.Write("Which goal do you want to delete? ");
                if (!int.TryParse(Console.ReadLine(), out int choice)) // Gets the user input as a number, if the user types anything different, this will repeat
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                if (choice < 1 || choice > _goals.Count) // Safe code, if the number is not withing the list index this will tell
                {
                    Console.WriteLine("Invalid choice. Please select a valid goal.");
                    continue;
                }

                Goal selectedGoal = _goals[choice - 1]; // Creates a Goal object with the list index and polymorphs it into the specific object type
                Console.WriteLine($"Are you sure you want to delete {selectedGoal._name}? (Y/N) "); // Asks the user again
                string certain = Console.ReadLine();
                if (certain.ToUpper() == "Y") // If they type Y deletes the goal
                {
                    _goals.Remove(selectedGoal); // Removes the goal from the list
                    Console.WriteLine($"{selectedGoal._name} goal deleted."); // Tells the user wich goal has been removed
                }
                else // If the user types anything other than Y, this will break
                {
                    break;
                }              

                DisplayPlayerInfo();
                break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine(e.Message);
        }
    }
}