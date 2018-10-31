using ORMDemo.Entities;

namespace ORMDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var group = new Group();
            var student = new Student
            {
                Name = "Вася Пупкин"
            };
            group.AddStudent(student);
        }
    }
}
