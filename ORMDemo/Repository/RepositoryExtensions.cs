using System;
using System.Linq.Expressions;

namespace ORMDemo.Repository.Extensions
{
    public static class RepositoryExtensions
    {
        public static Expression<Func<T2, T3>> Evaluate<T1, T2, T3>(
            this Expression<Func<T1, Expression<Func<T2, T3>>>> expression,
            T1 argument) =>
            expression.Compile().Invoke(argument);
    }
}
