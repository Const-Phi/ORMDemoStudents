using System.Collections.Generic;

namespace ORMDemo.Entities
{
    public class Subject : Entity
    {
        public virtual string Name { get; set; }

        public virtual ISet<Professor> Professors { get; set; } = new HashSet<Professor>();

        public override string ToString() => Name;

        public virtual bool AddProfessor(Professor professor) => Professors.Add(professor);
    }
}
