using System;
using System.Configuration;
using System.Data.SqlClient;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace ORMDemo.Utilits
{
    static class SessionConfigurator
    {
        //при использовании соглашения по первичному ключу                      
        //.Conventions.Add<MyIdConvention>() 
        //при использовании специального соглашения       
        // .Conventions.Add<MyNoteConvention>()   
        //при использовании соглашения по внешнему ключу            
        // .Conventions.Add<MyForeignKeyConvention>())

        private static volatile object locker = new object();

        private static ISessionFactory SessionFactory;

        private static ISessionFactory GetSessionFactory(String connectionString)
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings
                    .AddFromAssembly(typeof(Program).Assembly))
                .BuildConfiguration();
            return configuration.BuildSessionFactory();
        }

        private static string GetConnectionString()
        {
            var Prefix = "mssql";
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = ConfigurationManager.AppSettings[$"{Prefix}DatabaseLocation"],
                InitialCatalog = ConfigurationManager.AppSettings[$"{Prefix}DatabaseName"],
                UserID = ConfigurationManager.AppSettings[$"{Prefix}DatabaseLogin"],
                Password = ConfigurationManager.AppSettings[$"{Prefix}DatabasePassword"]
            };
            return builder.ConnectionString;
        }

        public static ISessionFactory GetSessionFactory()
        {
            if (SessionFactory == null)
                lock(locker)
                    if (SessionFactory == null)
                        SessionFactory = GetSessionFactory(GetConnectionString());
            return SessionFactory;
        }
    }
}
