using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                var command = new SqlCommand()
                {
                    CommandText = "select count(*) from [Library].[Books];",
                    Connection = connection
                };

                var booksCount = command.ExecuteScalar();
                Console.WriteLine($"count = {booksCount}");

                //var reader = command.ExecuteReader();
                //var books = new List<Book>();
                //while (reader.HasRows)
                //{
                //    // reader.

                //    books.Add(new Book(/*...*/));
                //}

                if (connection.State != ConnectionState.Closed)
                    connection.Close();
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
                UserID = ConfigurationManager.AppSettings[$"{Prefix}DatabaseLogin"],
                Password = ConfigurationManager.AppSettings[$"{Prefix}DatabasePassword"]
            };
            return builder.ConnectionString;
        }
    }
}
