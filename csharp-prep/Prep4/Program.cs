using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = 1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
            else 
            {
                break;
            }
        }

        double sum = numbers.Sum();
        double avg = sum / numbers.Count();
        double max = numbers.Max();

        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg.ToString()}", CultureInfo.InvariantCulture);
        Console.WriteLine($"The largest number is: {max}");
        
        List<int> positives = new List<int>();
        foreach(int n in numbers)
        {
            if (n > 0)
            {
                positives.Add(n);
            }
        }

        double min = positives.Min();

        Console.WriteLine($"The smallest positive number is: {min}");

        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}