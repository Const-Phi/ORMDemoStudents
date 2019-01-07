using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace ORMDemo.Entities
{
    public class Subject : Entity
    {
        public virtual string Name { get; set; }

        public virtual ISet<Professor> Professors { get; set; } = new LinkedHashSet<Professor>();

        public override string ToString() => Name;

        public virtual bool AddProfessor(Professor professor) => Professors.Add(professor);
    }
}
