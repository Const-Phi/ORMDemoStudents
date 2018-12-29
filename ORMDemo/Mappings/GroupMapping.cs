using FluentNHibernate.Mapping;
using ORMDemo.Entities;

namespace ORMDemo.Mappings
{
    class GroupMapping : ClassMap<Group>
    {
        public GroupMapping()
        {
            Table($"Faculty.{nameof(Group)}s");

            Id(x => x.Id);

            Map(x => x.Name);

            HasMany(x => x.Students);
        }
    }
}
