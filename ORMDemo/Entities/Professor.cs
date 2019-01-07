using System.Collections.Generic;

namespace ORMDemo.Entities
{
    public class Professor : Entity
    {
        public virtual string Name { get; set; }

        public virtual ISet<Subject> Subjects { get; set; } = new HashSet<Subject>();

        public override string ToString() => Name;

        public virtual bool AddSubject(Subject subject)
        {
            if (Subjects.Contains(subject))
                return false;

            Subjects.Add(subject);
            subject.AddProfessor(this);
            return true;
        }
    }
}
