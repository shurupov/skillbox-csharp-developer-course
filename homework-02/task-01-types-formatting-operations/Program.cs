using System;

namespace task_01_types
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fullName = "Пушкин Александр Сергеевич";
            int age = 37;
            string email = "pushkin@lycey.ru";
            int programmingScores = 99;
            int mathScores = 77;
            int physicsScores = 89;
            
            Console.WriteLine($"{"ФИО:", 26} {fullName}");
            Console.WriteLine($"{"Возраст:", 26} {age}");
            Console.WriteLine($"{"Email:", 26} {email}");
            Console.WriteLine($"{"Баллы по программированию:", 26} {programmingScores}");
            Console.WriteLine($"{"Баллы по математике:", 26} {mathScores}");
            Console.WriteLine($"{"Баллы по физике:", 26} {physicsScores}");

            Console.ReadKey();

            int sum = programmingScores + mathScores + physicsScores;
            Console.WriteLine($"{"Сумма баллов:", 26} {sum}");

            double average = (double) sum / 3;
            Console.WriteLine($"{"Средний балл:", 26} {average}");
            
            Console.ReadKey();
        }
    }
}