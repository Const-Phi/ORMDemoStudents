using FluentNHibernate.Mapping;
using ORMDemo.Entities;

namespace ORMDemo.Mappings
{
    class StudentMapping : ClassMap<Student>
    {
        public StudentMapping()
        {
            Table($"Faculty.{nameof(Student)}s");

            Id(x => x.Id).GeneratedBy.Assigned();
            
            Map(x => x.Name).Column("FullName").Not.Nullable();

            References(x => x.Group);
        }
    }

    class GroupMapping : ClassMap<Group>
    {
        public GroupMapping()
        {
            Table($"Faculty.{nameof(Group)}s");

            Id(x => x.Id);

            HasMany(x => x.Students);
        }
    }
}
