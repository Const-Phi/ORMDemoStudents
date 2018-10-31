namespace ORMDemo.Entities
{
    public class Entity
    {
        public virtual int Id { get; set; }

        public bool IsNew => Id == default(int);
    }
}
