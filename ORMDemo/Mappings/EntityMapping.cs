using FluentNHibernate.Mapping;
using ORMDemo.Entities;

namespace ORMDemo.Mappings
{
    class EntityMapping<TEntity> : ClassMap<TEntity> where TEntity : Entity
    {
        public EntityMapping()
        {
            Schema(SchemaName);

            Table($"{typeof(TEntity).Name}s");

            Id(x => x.Id);
        }

        public const string SchemaName = "Faculty";
    }
}
