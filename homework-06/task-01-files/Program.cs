using System;
using System.IO;

namespace task_01_files
{
    internal class Program
    {
        //You can change this according to your file system and file destination 
        private const string FilePath = "/home/shurupov/csharp/file.txt";
        
        public static void Main(string[] args)
        {
            Console.Write("Enter: Display data on the screen [1] / Enter data [2]: ");
            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine();

            if (key == ConsoleKey.D1)
            {
                display();
            }
            else if (key == ConsoleKey.D2)
            {
                append();
            }
        }

        private static void display()
        {
            StreamReader reader = new StreamReader(new BufferedStream(new FileStream(FilePath, FileMode.Open)));
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        private static void append()
        {
            StreamWriter writer = new StreamWriter(new BufferedStream(new FileStream(FilePath, FileMode.Append)));
            int id = 0;
            do
            {
                Console.WriteLine();
                id++;
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Enter height: ");
                int height = int.Parse(Console.ReadLine());
                Console.Write("Enter birth date: ");
                string birthDate = Console.ReadLine();
                Console.Write("Enter birth place: ");
                string birthPlace = Console.ReadLine();
                DateTime now = new DateTime();
                writer.WriteLine($"{id}#{now.ToShortDateString()} {now.ToShortTimeString()}#{name}#{age}#{height}#{birthDate}#{birthPlace}");
                
                Console.WriteLine("Закончить [1] / Продолжить [2]");
                
            } while (Console.ReadKey().Key != ConsoleKey.D1);
            
            writer.Close();
        }
    }
}