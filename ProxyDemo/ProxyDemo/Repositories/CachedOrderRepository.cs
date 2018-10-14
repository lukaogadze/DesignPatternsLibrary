using System.Runtime.Caching;
using ProxyDemo.Entities;

namespace ProxyDemo.Repositories
{
    public class CachedOrderRepository : RemoteOrderRepository
    {
        public override OrderEntity GetById(int id)
        {
            string cacheKey = "OrderEntity-" + id;
            var entity = MemoryCache.Default[cacheKey] as OrderEntity;
            if(entity == null)
            {
                entity = base.GetById(id);
                var cacheItem = new CacheItem(cacheKey, entity);
                var policy = new CacheItemPolicy();
                MemoryCache.Default.Add(cacheItem, policy);
            }
            return entity;
        }
    }
}