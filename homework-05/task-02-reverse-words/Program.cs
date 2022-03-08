using System;

namespace task_02_reverse_words
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentence:");
            string line = Console.ReadLine();
            string reversed = ReversWords(line);
            Console.WriteLine(reversed);
        }

        private static string ReversWords(string inputPhrase)
        {
            string result = "";
            string[] words = Split(inputPhrase);
            for (int i = words.Length - 1; i >= 0; i--)
            {
                result += words[i] + ' ';
            }

            return result;
        }
        
        private static string[] Split(string line)
        {
            return line.Split(' ');
        }
    }
}