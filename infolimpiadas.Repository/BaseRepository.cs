using infolimpiadas.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace infolimpiadas.Repository
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        protected DbContext _db;

        protected BaseRepository() { }

        protected BaseRepository(DbContext db)
        {
            _db = db;
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            return _db.Set<TEntity>().ToListAsync();
        }

        public Task<List<TEntity>> GetAll(string include)
        {
            return _db.Set<TEntity>().Include(include).ToListAsync();
        }

        public Task<List<TEntity>> GetAll(IEnumerable<string> includes)
        {
            var query = _db.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.ToListAsync();
        }

        public virtual Task<TEntity> Get(TKey id)
        {
            return _db.Set<TEntity>().SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Task<TEntity> Get(TKey id, string include)
        {
            return _db.Set<TEntity>().Include(include).SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Task<TEntity> Get(TKey id, IEnumerable<string> includes)
        {
            var query = _db.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public virtual TEntity Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().AddRange(entities);
        }

        public virtual void Delete(TKey id)
        {
            var entity = new TEntity { Id = id };
            _db.Set<TEntity>().Attach(entity);
            _db.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return (await _db.SaveChangesAsync()) > 0;
        }

        public virtual void Update(TEntity entity)
        {
            _db.Set<TEntity>().Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}
