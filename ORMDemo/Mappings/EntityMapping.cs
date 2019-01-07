using System;
using FluentNHibernate.Mapping;
using ORMDemo.Entities;

namespace ORMDemo.Mappings
{
    class EntityMapping<TEntity> : ClassMap<TEntity> where TEntity : Entity
    {
        public EntityMapping()
        {
            Table(TableNameByType(typeof(TEntity)));

            Id(x => x.Id);
        }

        public static string TableNameByType(Type type, string schemaName = "Faculty") => $"{schemaName}.{type.Name}s";
    }
}
