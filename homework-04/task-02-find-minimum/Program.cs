using System;

namespace task_02_find_minimum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter sequence size: ");
            int size = int.Parse(Console.ReadLine());

            int[] sequence = new int[size];

            Console.WriteLine("Enter sequence numbers:");
            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            int min = int.MaxValue;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] < min)
                {
                    min = sequence[i];
                }
            }
            
            Console.WriteLine($"Minimal number of the sequence is {min}");
        }
    }
}