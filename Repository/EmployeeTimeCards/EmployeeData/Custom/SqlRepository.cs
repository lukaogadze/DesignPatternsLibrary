using System;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using EmployeeDomain.Custom;

namespace EmployeeData.Custom {
    public class SqlRepository<T> : IRepository<T>
                                    where T : class, IEntity {

        public SqlRepository(ObjectContext context) {
            _objectSet = context.CreateObjectSet<T>();
        }

       public IQueryable<T> Find(Expression<Func<T, bool>> predicate) {
            return _objectSet.Where(predicate);
        }

        public void Add(T newEntity) {
            _objectSet.AddObject(newEntity);
        }

        public void Remove(T entity) {
            _objectSet.DeleteObject(entity);
        }


        public IQueryable<T> FindAll()
        {
            return _objectSet;
        }

        public T FindById(int id)
        {
            return _objectSet.Single(o => o.Id == id);
        }

        protected ObjectSet<T> _objectSet;
    }
}