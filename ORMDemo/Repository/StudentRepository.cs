using System;
using System.Collections.Generic;
using ORMDemo.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace ORMDemo.Repository
{
    public class StudentRepository : BaseRepository<Student>
    {
        [Obsolete("Конструктор для создания репозитория через фабрику. Использовать напрямую не рекомендуется.")]
        public StudentRepository() { }

        public static StudentRepository GetInstance() => GetInstance<StudentRepository>();

        public IEnumerable<Student> GetByGroupNameInvalid(string groupName)
        {
            return GetFiltered(s => s.Group.Name == groupName);
        }

        public static Expression<Func<Student, bool>> GroupNameFilter =>
            (student) => student.Name.Contains("Дмитрий");

        public IEnumerable<Student> GetByGroupName(string groupName)
            => GetAll().Where(GroupNameFilter).ToList();
    }
}
