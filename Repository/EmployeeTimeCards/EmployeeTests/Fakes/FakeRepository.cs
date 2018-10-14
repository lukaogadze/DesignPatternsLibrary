using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EmployeeDomain.Custom;

namespace EmployeeTests.Fakes
{
    public class FakeRepository<T> : IRepository<T> where T: class, IEntity
    {
            public FakeRepository()
                : this(Enumerable.Empty<T>())
            {
            }

            public FakeRepository(IEnumerable<T> entities)
            {
                _set = new HashSet<T>();
                foreach (var entity in entities)
                {
                    _set.Add(entity);
                }

                _queryableSet = _set.AsQueryable();
            }

        public IQueryable<T> FindAll()
        {
            return _queryableSet;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _queryableSet.Where(predicate);
        }

        public T FindById(int id)
        {
            return _queryableSet.Single(e => e.Id == id);
        }

        public void Add(T entity)
        {
            _set.Add(entity);
        }

        public void Remove(T entity)
        {
            _set.Remove(entity);
        }


        readonly HashSet<T> _set;
        readonly IQueryable<T> _queryableSet;        
    }
}