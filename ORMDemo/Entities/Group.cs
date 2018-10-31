using System;
using System.Collections.Generic;

namespace ORMDemo.Entities
{
    public class Group : Entity
    {
        public virtual string Name { get; set; }

        public virtual List<Student> Students { get; set; } = new List<Student>();

        public void AddStudent(Student student)
        {
            if (ReferenceEquals(student, null))
                throw new ArgumentNullException(nameof(student));

            if (Students.Contains(student))
                throw new InvalidOperationException("Такой студент уже есть!");

            Students.Add(student);
            student.Group = this;
        }
    }
}
