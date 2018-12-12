using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ORMDemo.Entities;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using ORMDemo.Repository;

namespace ORMDemo
{
    class Program
    {
        static void Main()
        {
            var repo = StudentRepository.GetInstance();
            var students = repo.GetByGroupName("ТУУ-151");
            foreach (var student in students)
                Console.WriteLine(student);
        }
    }
}
