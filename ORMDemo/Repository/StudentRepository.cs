using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMDemo.Entities;

namespace ORMDemo.Repository
{
    public class StudentRepository : BaseRepository<Student>
    {
        protected StudentRepository() { }

        public static StudentRepository GetInstance() => GetBaseInstance() as StudentRepository;

        public IEnumerable<Student> GetByGroupName(string groupName)
        {
            return GetFiltered(s => s.Group.Name == groupName);
        }
    }
}
