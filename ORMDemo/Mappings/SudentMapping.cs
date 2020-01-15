using ORMDemo.Entities;

namespace ORMDemo.Mappings
{
    class StudentMapping : EntityMapping<Student>
    {
        public StudentMapping()
        {
            Map(x => x.Name).Column("FullName").Not.Nullable();

            References(x => x.Group);
        }
    }
}
