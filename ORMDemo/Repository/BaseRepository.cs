using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using ORMDemo.Entities;
using ORMDemo.Utilits;

namespace ORMDemo.Repository
{
    public class BaseRepository<T> where T : Entity
    {
        private static BaseRepository<T> instance;

        private static volatile object locker = new object();

        protected BaseRepository()
        {

        }

        protected static BaseRepository<T> GetBaseInstance()
        {
            if (instance == null)
                lock (locker)
                    if (instance == null)
                        instance = new BaseRepository<T>();

            return instance;
        }

        private ISession session;

        protected ISession Session
        {
            get
            {
                if (session == null)
                    session = SessionConfigurator.GetSessionFactory().OpenSession();
                return session;
            }
        }

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public IEnumerable<T> GetFiltered(Func<T, bool> filter)
        {
            return GetAll().Where(filter).ToList<T>();
        }
    }
}
