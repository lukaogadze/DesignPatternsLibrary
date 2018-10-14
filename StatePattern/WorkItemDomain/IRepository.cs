using System;
using System.Linq;
using System.Linq.Expressions;

namespace WorkItemDomain
{
	public interface IRepository<T> where T : class, IEntity
	{
		IQueryable<T> FindAll();
		IQueryable<T> Find(Expression<Func<T, bool>> predicate);
		T FindById(int id);
		void Add(T newEntity);
		void Remove(T entity);
	}
}