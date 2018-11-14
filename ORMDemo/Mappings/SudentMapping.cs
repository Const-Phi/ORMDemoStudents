using System;
using FluentNHibernate.Mapping;
using ORMDemo.Entities;

namespace ORMDemo.Mappings
{
    class StudentMapping : ClassMap<Student>
    {
        public StudentMapping()
        {
            Table($"SchemaName.{nameof(Student)}s");

            Id(x => x.Id);

            Map(x => x.Name).Column("FullName");
        }
    }
}
