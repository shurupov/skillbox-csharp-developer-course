using System;

namespace task_01_add_even
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число");
            uint number = uint.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine("Число чётное");
            }
            else
            {
                Console.WriteLine("Число нечётное");
            }

            Console.ReadLine();
        }
    }
}