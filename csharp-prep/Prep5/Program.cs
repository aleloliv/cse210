using System;

class Program
{
    static void Main(string[] args)
    {
        int number;
        string name;
        int square;

        DisplayWelcome();
        name = PromptUserName();
        number = PromptUserNumber();
        square = SquareNumber(number);
        DisplayResult(name, square);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please type your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please insert your favorite integer: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int number)
    {
        Console.WriteLine("Name: " 
                        + name
                        + ", the square of your number is "
                        + number.ToString());
    }
}