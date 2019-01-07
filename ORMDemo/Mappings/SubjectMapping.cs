using ORMDemo.Entities;

namespace ORMDemo.Mappings
{
    class SubjectMapping : EntityMapping<Subject>
    {
        public SubjectMapping()
        {
            Map(x => x.Name)
                .Column("FullName")
                .Length(255)
                .Not.Nullable();

            HasManyToMany(x => x.Professors)
                .Cascade.All()
                .Inverse()
                .Schema(SchemaName)
                .Table("ProfessorToSubjects")
                .AsSet();
        }
    }
}
