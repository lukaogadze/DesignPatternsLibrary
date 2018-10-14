using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WorkItemDomain
{
	public class XmlRepository<T> : IRepository<T>
		where T : class, IEntity
	{
		protected List<T> DataList;

		public XmlRepository()
		{
			DataList = new List<T>();
		}

		#region IRepository<T> Members

		public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
		{
			return DataList.AsQueryable().Where(predicate);
		}

		public void Add(T newEntity)
		{
			int maxId = 0;
			if (DataList.Count() > 0)
			{
				maxId = DataList.AsQueryable().Max(x => x.Id);
			}
			newEntity.Id = maxId + 1;
			DataList.Add(newEntity);
		}

		public void Remove(T entity)
		{
			T x = FindById(entity.Id);
			DataList.Remove(x);
		}

		public IQueryable<T> FindAll()
		{
			return DataList.AsQueryable();
		}

		public T FindById(int id)
		{
			return DataList.Find(e => e.Id == id);
		}

		#endregion
	}
}