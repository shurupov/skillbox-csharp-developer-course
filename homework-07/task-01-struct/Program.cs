using System;
using System.IO;

namespace task_01_struct
{
    internal class Program
    {
        //You can change this according to your file system and file destination 
        private const string FilePath = "/home/shurupov/csharp/file.txt";
        private static readonly EmployeeService EmployeeService = new EmployeeService();

        public static void Main(string[] args)
        {
            Console.WriteLine("Select the action");
            Console.WriteLine("Display data on the screen [1]");
            Console.WriteLine("Add entry [2]");
            Console.WriteLine("Modify entry [3]");
            Console.WriteLine("Remove entry [4]");
            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine();

            if (key == ConsoleKey.D1)
            {
                Display();
            }
            else if (key == ConsoleKey.D2)
            {
                Add();
            }
            else if (key == ConsoleKey.D3)
            {
                Modify();
            }
            else if (key == ConsoleKey.D4)
            {
                Remove();
            }
        }

        private static void Display()
        {
            Console.Write("Enter employee id: ");
            int id = int.Parse(Console.ReadLine());
            Employee employee = EmployeeService.Display(id);
            Console.WriteLine(employee);
        }

        private static void Add()
        {
            Employee employee = new Employee();
            Console.Write("Enter Id: ");
            employee.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            employee.Name = Console.ReadLine();
            Console.Write("Enter Age: ");
            employee.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter Height: ");
            employee.Height = int.Parse(Console.ReadLine());
            Console.Write("Enter BirthDate: ");
            employee.BirthDate = Console.ReadLine();
            Console.Write("Enter BirthPlace: ");
            employee.BirthPlace = Console.ReadLine();
            
            EmployeeService.Add(employee);
        }

        private static void Modify()
        {
            Console.Write("Enter employee id: ");
            int id = int.Parse(Console.ReadLine());
            Employee employee = EmployeeService.Display(id);

            string enteredLine;
            Console.Write($"Enter Name ({employee.Name}): ");
            enteredLine = Console.ReadLine();
            employee.Name = string.IsNullOrEmpty(enteredLine) ? employee.Name : enteredLine;
            Console.Write($"Enter Age ({employee.Age}): ");
            enteredLine = Console.ReadLine();
            employee.Age = string.IsNullOrEmpty(enteredLine) ? employee.Age : int.Parse(enteredLine);
            Console.Write($"Enter Height ({employee.Height}): ");
            enteredLine = Console.ReadLine();
            employee.Height = string.IsNullOrEmpty(enteredLine) ? employee.Height : int.Parse(enteredLine);
            Console.Write($"Enter BirthDate ({employee.BirthDate}): ");
            enteredLine = Console.ReadLine();
            employee.BirthDate = string.IsNullOrEmpty(enteredLine) ? employee.BirthDate : enteredLine;
            Console.Write($"Enter BirthPlace ({employee.BirthPlace}): ");
            enteredLine = Console.ReadLine();
            employee.BirthPlace = string.IsNullOrEmpty(enteredLine) ? employee.BirthPlace : enteredLine;
            
            EmployeeService.Modify(employee);
            
        }

        private static void Remove()
        {
            Console.Write("Enter employee id: ");
            int id = int.Parse(Console.ReadLine());
            EmployeeService.Remove(id);
        }
    }
}