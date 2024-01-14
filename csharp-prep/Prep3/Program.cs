using System;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        char game = 'y';
        while (true)
        {
            int number = rnd.Next(1, 100);

            int tries = 0;

            int guess = 0;

            while (guess != number)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (guess < number)
                {
                    Console.WriteLine("Higher");
                    tries++;
                }
                else if (guess > number)
                {
                    Console.WriteLine("Lower");
                    tries++;
                }
                else
                {
                    Console.WriteLine($"You found it! It took you {tries} tries.");
                    Console.Write("Would you like to play again? (y/n) ");
                    game = char.Parse(Console.ReadLine());
                    if (game == 'y')
                    {
                        continue;
                    }
                    else 
                    {
                        break;
                    }
                }
            }
            if (game == 'n')
            {
                break;
            }
            else
            {
                continue;
            }
        }
    }
}