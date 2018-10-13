using System;
using System.Collections.Generic;
using System.Linq;

namespace PS.Auto.Domain
{
    public class Repository<T> where T : IEntity
    {
        readonly Dictionary<Guid, T> memoryTable;

        public Repository()
        {
            memoryTable = new Dictionary<Guid, T>();
        }

        public T Find(Guid id)
        {
            return memoryTable[id];
        }

        public IEnumerable<T> FindAll(Func<T, bool> predicate)
        {
            return memoryTable.Values.Where(predicate);
        }

        public IEnumerable<T> ListAll()
        {
            return memoryTable.Values;
        }

        public void Save(T entity)
        {
            memoryTable[entity.Id] = entity;
        }

        public void Delete(T toDelete)
        {
            memoryTable.Remove(toDelete.Id);
        }
    }
}
