using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ORMDemo.Entities;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;


namespace ORMDemo
{
    class Book { }

    class Program
    {
        //при использовании соглашения по первичному ключу                      
        //.Conventions.Add<MyIdConvention>() 
        //при использовании специального соглашения       
        // .Conventions.Add<MyNoteConvention>()   
        //при использовании соглашения по внешнему ключу            
        // .Conventions.Add<MyForeignKeyConvention>())

        public static ISessionFactory GetSessionFactory(String connectionString)
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings
                    .AddFromAssembly(typeof(Program).Assembly))
                .BuildConfiguration();
            return configuration.BuildSessionFactory();
        }


        static void Main()
        {
            using (var session = GetSessionFactory(GetConnectionString()).OpenSession())
            {
                try
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var students = session.CreateCriteria<Student>().List();
                        foreach (var student in students)
                        {
                            Console.WriteLine(student);
                        }

                        var s = new Student { Id = 123, Name = "Котова Анастасия" };
                        session.Save(s);

                        transaction.Commit();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    session.Close();
                }
            }

            /*
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                var command = new SqlCommand()
                {
                    CommandText = "select count(*) from [Library].[Books];",
                    Connection = connection
                };

                var booksCount = command.ExecuteScalar();
                Console.WriteLine($"count = {booksCount}");

                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            */
        }

        private static string GetConnectionString()
        {
            var Prefix = "mssql";
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = ConfigurationManager
.AppSettings[$"{Prefix}DatabaseLocation"],
                InitialCatalog = ConfigurationManager
.AppSettings[$"{Prefix}DatabaseName"],
                UserID = ConfigurationManager.AppSettings[$"{Prefix}DatabaseLogin"],
                Password = ConfigurationManager.AppSettings[$"{Prefix}DatabasePassword"]
            };
            return builder.ConnectionString;
        }
    }
}
