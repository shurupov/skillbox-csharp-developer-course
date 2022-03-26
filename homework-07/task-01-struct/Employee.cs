using System;

namespace task_01_struct
{
    public struct Employee
    {
        public int Id;
        public DateTime Created;
        public string Name;
        public int Age;
        public int Height;
        public DateTime BirthDate;
        public string BirthPlace;

        public Employee(int id, DateTime created, string name, int age, int height, DateTime birthDate, string birthPlace)
        {
            Id = id;
            Created = created;
            Name = name;
            Age = age;
            Height = height;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
        }

        public override string ToString()
        {
            return $"Employee(Id={Id}, Created={Created}, Name={Name}, Age={Age}, Height={Height}, BirthDate={BirthDate}, BirthPlace={BirthPlace})";
        }
    }
}