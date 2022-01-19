using System;

namespace task_03_prime_number
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            uint number = uint.Parse(Console.ReadLine());
            bool isPrime = true;
            uint i = 2;
            while (i < number)
            {
                if (number % i++ == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            Console.WriteLine("Введённое число " + (isPrime ? "простое" : "не простое"));
            
            
        }
    }
}