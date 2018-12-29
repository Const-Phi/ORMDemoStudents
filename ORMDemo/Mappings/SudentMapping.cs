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
}
