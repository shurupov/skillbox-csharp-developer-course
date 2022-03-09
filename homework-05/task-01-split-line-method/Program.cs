using System;

namespace task_01_split_line_method
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentence:");
            string line = Console.ReadLine();
            string[] words = Split(line);
            Print(words);
        }

        private static string[] Split(string line)
        {
            return line.Split(' ');
        }

        private static void Print(string[] words)
        {
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}