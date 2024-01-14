using System;

class Program
{
    static void Main(string[] args)
    {
        System.Console.Write("What is your first name? ");
        string fname = Console.ReadLine();
        System.Console.Write("What is your last name? ");
        string lname = Console.ReadLine();
        System.Console.WriteLine();
        System.Console.WriteLine($"Your name is {lname}, {fname} {lname}");
    }
}