using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using ORMDemo.Entities;
using ORMDemo.Repository.Extensions;

namespace ORMDemo.Repository
{
    public class StudentRepository : BaseRepository<Student>
    {
        [Obsolete("Конструктор для создания репозитория через фабрику. Использовать напрямую не рекомендуется.", true)]
        public StudentRepository() { }

        public static StudentRepository GetInstance() => GetInstance<StudentRepository>();

        public static Expression<Func<string, Expression<Func<Student, bool>>>> GroupNameFilterExpression =>
            name => student => student.Group.Name == name;

        public IEnumerable<Student> GetByGroupName(string groupName) =>
            GetFiltered(GroupNameFilterExpression.Evaluate(groupName));
    }
}
