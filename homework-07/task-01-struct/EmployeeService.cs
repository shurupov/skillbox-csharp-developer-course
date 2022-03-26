using System;
using System.IO;
using System.Linq;

namespace task_01_struct
{
    public class EmployeeService
    {
        //You can change this according to your file system and file destination 
        private const string FilePath = "/home/shurupov/csharp/file.txt";
        private const string TmpFilePath = "/home/shurupov/csharp/tmpfile.txt";
        private const string BackupFilePath = "/home/shurupov/csharp/backupfile.txt";
        
        public Employee[] DisplayAll()
        {
            int count = File.ReadLines(FilePath).Count();
            Employee[] employees = new Employee[count];
            int cursor = 0;
            StreamReader reader = new StreamReader(new BufferedStream(new FileStream(FilePath, FileMode.Open)));
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Employee employee = LineToEmployee(line);
                employees[cursor++] = employee;
            }
            reader.Close();

            return employees;
        }
        
        public Employee Display(int id)
        {
            StreamReader reader = new StreamReader(new BufferedStream(new FileStream(FilePath, FileMode.Open)));
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Employee employee = LineToEmployee(line);
                if (employee.Id == id)
                {
                    reader.Close();
                    return employee;
                }
            }
            reader.Close();
            
            return new Employee();
        }

        public void Add(Employee e)
        {
            StreamWriter writer = new StreamWriter(new BufferedStream(new FileStream(FilePath, FileMode.Append)));
            e.Created = DateTime.Now;
            writer.WriteLine(EmployeeToLine(e));
            writer.Close();
        }

        public void Modify(Employee e)
        {
            StreamReader reader = new StreamReader(new BufferedStream(new FileStream(FilePath, FileMode.Open)));
            StreamWriter writer = new StreamWriter(new BufferedStream(new FileStream(TmpFilePath, FileMode.OpenOrCreate)));
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Employee employee = LineToEmployee(line);
                if (employee.Id == e.Id)
                {
                    writer.WriteLine(EmployeeToLine(e));
                }
                else
                {
                    writer.WriteLine(line);
                }
            }
            reader.Close();
            writer.Close();
            
            File.Delete(FilePath);
            File.Copy(TmpFilePath, FilePath);
            File.Delete(TmpFilePath);
        }
        public void Remove(int id)
        {
            StreamReader reader = new StreamReader(new BufferedStream(new FileStream(FilePath, FileMode.Open)));
            StreamWriter writer = new StreamWriter(new BufferedStream(new FileStream(TmpFilePath, FileMode.OpenOrCreate)));
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Employee employee = LineToEmployee(line);
                if (employee.Id != id)
                {
                    writer.WriteLine(line);
                }
            }
            reader.Close();
            writer.Close();
            
            File.Delete(FilePath);
            File.Copy(TmpFilePath, FilePath);
            File.Delete(TmpFilePath);
        }

        public Employee[] Search(DateTime from, DateTime to)
        {
            int count = File.ReadLines(FilePath).Count();
            
            Employee[] employees = new Employee[count];
            int cursor = 0;
            
            StreamReader reader = new StreamReader(new BufferedStream(new FileStream(FilePath, FileMode.Open)));
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Employee employee = LineToEmployee(line);
                if (employee.BirthDate >= from && employee.BirthDate <= to)
                {
                    employees[cursor++] = employee;
                }
            }
            reader.Close();
            
            Array.Resize(ref employees, cursor);
            return employees;
        }
        
        public Employee[] Sort(bool asc)
        {
            int count = File.ReadLines(FilePath).Count();
            Employee[] employees = new Employee[count];
            int cursor = 0;
            StreamReader reader = new StreamReader(new BufferedStream(new FileStream(FilePath, FileMode.Open)));
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Employee employee = LineToEmployee(line);
                employees[cursor++] = employee;
            }
            reader.Close();
            
            Array.Sort(
                employees, 
                (employee1, employee2) => 
                    (employee1.BirthDate < employee2.BirthDate && asc)
                        || (employee1.BirthDate > employee2.BirthDate && !asc) ? -1 : 1
            );

            return employees;
        }

        private string EmployeeToLine(Employee e)
        {
            return $"{e.Id}#{e.Created}#{e.Name}#{e.Age}#{e.Height}#{e.BirthDate.ToShortDateString()}#{e.BirthPlace}";
        }

        private Employee LineToEmployee(string line)
        {
            string[] values = line.Split('#');
            return new Employee(
                int.Parse(values[0]),
                DateTime.Parse(values[1]),
                values[2],
                int.Parse(values[3]),
                int.Parse(values[4]),
                DateTime.Parse(values[5]),
                values[6]
            );
        }
    }
}