using System;
using System.Linq.Expressions;

namespace Web.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}