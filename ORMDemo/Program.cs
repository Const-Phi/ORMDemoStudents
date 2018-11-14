using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using ORMDemo.Entities;

namespace ORMDemo
{
    class Book { }

    class Program
    {
        static void Main()
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var command = new SqlCommand()
                {
                    CommandText = "select * from Books",
                    Connection = connection
                };

                command.ExecuteNonQuery(); // для не select-запросов
                var reader = command.ExecuteReader();
                var books = new List<Book>();
                while (reader.HasRows)
                {
                    // reader.

                    books.Add(new Book(/*...*/));
                }
            }


            var group = new Group();
            var student = new Student
            {
                Name = "Вася Пупкин"
            };
            group.AddStudent(student);
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
                IntegratedSecurity = true
            };
            return builder.ConnectionString;
        }
    }
}
