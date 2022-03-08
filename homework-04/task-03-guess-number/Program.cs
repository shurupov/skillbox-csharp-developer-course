using System;

namespace task_03_guess_number
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter maximum of generated number: ");
            int max = int.Parse(Console.ReadLine());
            Random random = new Random();
            int number = random.Next(max);
            int guess;

            while (true)
            {
                Console.Write("Try to guess number: ");
                string entered = Console.ReadLine();
                if (entered == "")
                {
                    Console.WriteLine($"Generated number is {number}.");
                    break;
                }
                guess = int.Parse(entered);

                if (guess == number)
                {
                    Console.WriteLine($"You guessed right. Generated number is {number}.");
                    break;
                }

                if (guess > number)
                {
                    Console.WriteLine("Your guess is more.");
                }
                else
                {
                    Console.WriteLine("Your guess is less.");
                }
            };

        }
    }
}