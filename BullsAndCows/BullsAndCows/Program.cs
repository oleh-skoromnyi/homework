using System;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = 0;
            int bulls = 0;
            int cows = 0;
            bool success = false;
            while (!success)
            {
                Console.WriteLine("Choose lenght: ");
                success = int.TryParse(Console.ReadLine(), out lenght); 
            }
            success = false;
            bool repeat = true;
            var game = new ComputerOpponent(lenght);
            while(repeat)
            { 
                Console.WriteLine($"My prediction: {game.Start()}");
                while (!success)
                {
                    Console.WriteLine("How many bulls?");
                    success = int.TryParse(Console.ReadLine(), out bulls);
                    success = bulls > lenght ? false : success;
                }
                success = false; 
                while (!success)
                {
                    Console.WriteLine("How many cows?");
                    success = int.TryParse(Console.ReadLine(), out cows);
                    success = cows+bulls > lenght ? false : success;
                }
                success = false;
                while (bulls != lenght)
                {
                    Console.WriteLine($"My prediction: {game.Prediction(bulls,cows)}");
                    while (!success)
                    {
                        Console.WriteLine("How many bulls?");
                        success = int.TryParse(Console.ReadLine(), out bulls);
                        success = bulls > lenght ? false : success;
                    }
                    success = false;
                    while (!success)
                    {
                        Console.WriteLine("How many cows?");
                        success = int.TryParse(Console.ReadLine(), out cows);
                        success = cows + bulls > lenght ? false : success;
                    }
                    success = false;
                }
                Console.WriteLine("I guessed! Do you Want to repeat?(yes/no)");
                string repeatRequest = Console.ReadLine();
                repeat = repeatRequest.Contains("yes") ? true : false;
            }
        }
    }
}
