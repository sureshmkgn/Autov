using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Autovoice.Common.Types;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Autovoice.Common.Mongo
{
    public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : IIdentifiable
    {
        protected IMongoCollection<TEntity> CollectionMDB { get; }

		public MongoRepository(IMongoDatabase database, string collectionName)
		{
            CollectionMDB = database.GetCollection<TEntity>(collectionName);
           // var xx = CollectionMDB.CountAsync(new BsonDocument());
            // string str= xx.Result.ToString();
        }

        public async Task<TEntity> GetAsync(Guid id)
            => await GetAsync(e => e.Id == id);

        public async Task<TEntity> GetAsync(string filedname)
        {
            var filter = Builders<TEntity>.Filter.Eq(c=>c.Name, filedname);
            return  await CollectionMDB.Find(filter).SingleOrDefaultAsync();
  
            
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
            => await CollectionMDB.Find(predicate).SingleOrDefaultAsync();

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await CollectionMDB.Find(predicate).ToListAsync();

        public async Task<PagedResult<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate,
				TQuery query) where TQuery : PagedQueryBase
			=> await CollectionMDB.AsQueryable().Where(predicate).PaginateAsync(query);

		public async Task AddAsync(TEntity entity)
			=> await CollectionMDB.InsertOneAsync(entity);

		public async Task UpdateAsync(TEntity entity)
			=> await CollectionMDB.ReplaceOneAsync(e => e.Id == entity.Id, entity);

		public async Task DeleteAsync(Guid id)
			=> await CollectionMDB.DeleteOneAsync(e => e.Id == id);

		public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
			=> await CollectionMDB.Find(predicate).AnyAsync();
    }
}