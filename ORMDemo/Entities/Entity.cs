namespace ORMDemo.Entities
{
    public class Entity
    {
        public virtual int Id { get; set; }

        public virtual bool IsNew => Id == default(int);
    }
}
