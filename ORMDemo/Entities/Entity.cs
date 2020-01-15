using System;

namespace ORMDemo.Entities
{
    public class Entity : IEquatable<Entity>
    {
        public virtual int Id { get; set; }

        public virtual bool IsNew => Id == default(int);

        public virtual bool Equals(Entity other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(other, this))
                return true;

            return GetType() == other.GetType() 
                   && !IsNew && !other.IsNew
                   && Id == other.Id;
        }
    }
}
