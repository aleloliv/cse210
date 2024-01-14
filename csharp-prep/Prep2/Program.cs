using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int gradeNum = int.Parse(Console.ReadLine());
        
        char gradeLetter = ' ';

        if (gradeNum >= 90)
        {
            gradeLetter = 'A';
        }
        else if (gradeNum >= 80 && gradeNum < 90)
        {
            gradeLetter = 'B';
        }
        else if (gradeNum >= 70 && gradeNum < 80)
        {
            gradeLetter = 'C';
        }
        else if (gradeNum >= 60 && gradeNum < 70)
        {
            gradeLetter = 'D';
        }
        else
        {
            gradeLetter = 'F';
        }

        string sign = " ";

        if ((gradeNum % 10) >= 7 && gradeLetter != 'A' && gradeLetter != 'F')
        {
            sign = "+";
        }
        else if ((gradeNum % 10) < 3 && gradeLetter != 'F' && gradeNum != 100)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        if (gradeNum >= 70)
        {
            Console.WriteLine($"Congratulations! You have a {gradeLetter}{sign} your score was: {gradeNum}.\nYou've passed!");
        }
        else
        {
            Console.WriteLine($"I'm sorry, your grade was {gradeLetter}{sign}, your score was {gradeNum}. Don't give up, you'll get there next time!");
        }
    }
}