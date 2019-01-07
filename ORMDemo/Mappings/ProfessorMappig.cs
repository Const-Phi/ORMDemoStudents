using ORMDemo.Entities;

namespace ORMDemo.Mappings
{
    class ProfessorMappig : EntityMapping<Professor>
    {
        public ProfessorMappig()
        {
            Map(x => x.Name)
                .Column("FullName")
                .Length(255)
                .Not.Nullable();

            HasManyToMany(x => x.Subjects)
                .Cascade.SaveUpdate()
                .Schema("Faculty")
                .Table("ProfessorToSubjects")
                .AsSet();
        }
    }
}
