using ORMDemo.Entities;

namespace ORMDemo.Mappings
{
    class GroupMapping : EntityMapping<Group>
    {
        public GroupMapping()
        {
            Map(x => x.Name);

            HasMany(x => x.Students);
        }
    }
}
