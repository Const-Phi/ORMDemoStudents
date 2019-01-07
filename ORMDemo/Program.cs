using System;
using System.Linq;
using ORMDemo.Repository;

namespace ORMDemo
{
    class Program
    {
        static void Main()
        {
            var studentRepository = StudentRepository.GetInstance();
            var students = studentRepository.GetByGroupName("ТУУ-151");
            foreach (var student in students)
                Console.WriteLine(student);

            Console.WriteLine($"{Environment.NewLine}Professors:");

            var professors = ProfessorRepository.GetInstance()
                .GetAll()
                .ToList();

            foreach (var professor in professors)
            {
                Console.WriteLine($"\t{professor} ведёт:");
                foreach (var subject in professor.Subjects)
                    Console.WriteLine($"\t\t{subject}");
            }

            Console.WriteLine();
        }
    }
}
