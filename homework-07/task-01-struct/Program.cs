using System;

namespace task_01_struct
{
    internal class Program
    {
        private static readonly EmployeeService EmployeeService = new EmployeeService();

        public static void Main(string[] args)
        {
            ConsoleKey key;
            do
            {
                Console.WriteLine("Select the action");
                Console.WriteLine("Display all entries [1]");
                Console.WriteLine("Display one entry [2]");
                Console.WriteLine("Add entry [3]");
                Console.WriteLine("Modify entry [4]");
                Console.WriteLine("Remove entry [5]");
                Console.WriteLine("Search entries [6]");
                Console.WriteLine("Sort entries [7]");
                Console.WriteLine("Sort back entries [8]");
                Console.WriteLine("Exit [9]");
                key = Console.ReadKey().Key;
                Console.WriteLine();

                switch (key)
                {
                    case ConsoleKey.D1: DisplayAll(); break;
                    case ConsoleKey.D2: Display(); break;
                    case ConsoleKey.D3: Add(); break;
                    case ConsoleKey.D4: Modify(); break;
                    case ConsoleKey.D5: Remove(); break;
                    case ConsoleKey.D6: Search(); break;
                    case ConsoleKey.D7: Sort1(); break;
                    case ConsoleKey.D8: Sort2(); break;
                }
                
                Console.ReadKey();
            } while (key != ConsoleKey.D9);
        }

        private static void Display()
        {
            Console.Write("Enter employee id: ");
            int id = int.Parse(Console.ReadLine());
            Employee employee = EmployeeService.Display(id);
            Console.WriteLine(employee);
        }

        private static void DisplayAll()
        {
            Employee[] employees = EmployeeService.DisplayAll();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
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
            employee.BirthDate = DateTime.Parse(Console.ReadLine());
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
            employee.BirthDate = string.IsNullOrEmpty(enteredLine) ? employee.BirthDate : DateTime.Parse(enteredLine);
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
        
        private static void Search()
        {
            Console.Write("Enter start date: ");
            DateTime from = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter end date: ");
            DateTime to = DateTime.Parse(Console.ReadLine());
            Employee[] employees = EmployeeService.Search(from, to);
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        
        private static void Sort1()
        {
            Employee[] employees = EmployeeService.Sort(true);
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        
        private static void Sort2()
        {
            Employee[] employees = EmployeeService.Sort(false);
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}