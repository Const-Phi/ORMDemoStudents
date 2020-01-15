using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using NHibernate;

using ORMDemo.Entities;
using ORMDemo.Utilits;

namespace ORMDemo.Repository
{
    public class BaseRepository<TEntity> where TEntity : Entity
    {
        private static volatile BaseRepository<TEntity> instance;

        private static volatile object locker = new object();

        protected BaseRepository() { }

        protected static TRepository GetInstance<TRepository>()
            where TRepository : BaseRepository<TEntity>, new()
        {
            if (instance == null)
                lock (locker)
                    if (instance == null)
                        instance = new TRepository();

            return instance as TRepository;
        }

        private ISession session;

        protected ISession Session
        {
            get
            {
                if (session == null)
                    session = SessionConfigurator.GetSessionFactoryLazy().OpenSession();
                return session;
            }
        }

        public IQueryable<TEntity> GetAll() => Session.Query<TEntity>();

        public IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter) =>
            GetAll().Where(filter).ToList();
    }
}
