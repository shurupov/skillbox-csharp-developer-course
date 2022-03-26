using System;
using System.IO;

namespace task_01_struct
{
    public class EmployeeService
    {
        //You can change this according to your file system and file destination 
        private const string FilePath = "/home/shurupov/csharp/file.txt";
        private const string TmpFilePath = "/home/shurupov/csharp/tmpfile.txt";
        private const string BackupFilePath = "/home/shurupov/csharp/backupfile.txt";
        
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
            DateTime now = new DateTime();
            e.Created = new DateTime();
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

        private string EmployeeToLine(Employee e)
        {
            return $"{e.Id}#{e.Created}#{e.Name}#{e.Age}#{e.Height}#{e.BirthDate}#{e.BirthPlace}";
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
                values[5],
                values[6]
            );
        }
    }
}