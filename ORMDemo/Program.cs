using System;
using ORMDemo.Repository;

namespace ORMDemo
{
    class Program
    {
        static void Main()
        {
            var repo = StudentRepository.GetInstance();
            var students = repo.GetByGroupName("ТУУ-151");
            foreach (var student in students)
                Console.WriteLine(student);
        }
    }
}
