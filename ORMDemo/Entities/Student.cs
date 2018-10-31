namespace ORMDemo.Entities
{
    public class Student : Entity
    {
        public virtual string Name { get; set; }

        public virtual Group Group { get; set; }

        public override string ToString() => Name;
    }
}
