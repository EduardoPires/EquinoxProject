using System;
using System.Linq;
using Equinox.Domain.Interfaces;
using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Equinox.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EquinoxContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(EquinoxContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
       #region DataPager
        public DataPage<TEntity> PagerGet(int pageNumber, int pageLength, OrderBy<TEntity> orderby = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var startRow = (pageNumber - 1) * pageLength;
            var data = GetPage(startRow, pageLength, includes: includes, orderBy: orderby?.Expression);
            var totalCount = Count();
            return CreateDataPage(pageNumber, pageLength, data, totalCount);
        }
        public async Task<DataPage<TEntity>> PagerGetAsync(int pageNumber, int pageLength, OrderBy<TEntity> orderby = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var startRow = (pageNumber - 1) * pageLength;
            var data = await GetPageAsync(startRow, pageLength, includes: includes, orderBy: orderby?.Expression);
            var totalCount = await CountAsync();
            return CreateDataPage(pageNumber, pageLength, data, totalCount);
        }

        public DataPage<TEntity> PagerQuery(int pageNumber, int pageLength, Filter<TEntity> filter, OrderBy<TEntity> orderby = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var startRow = (pageNumber - 1) * pageLength;
            var data = QueryPage(startRow, pageLength, filter.Expression, includes: includes, orderBy: orderby?.Expression);
            var totalCount = Count(filter.Expression);
            return CreateDataPage(pageNumber, pageLength, data, totalCount);
        }

        public async Task<DataPage<TEntity>> PagerQueryAsync(int pageNumber, int pageLength, Filter<TEntity> filter, OrderBy<TEntity> orderby = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {

            var startRow = (pageNumber - 1) * pageLength;
            var data = await QueryPageAsync(startRow, pageLength, filter.Expression, includes: includes, orderBy: orderby?.Expression);
            var totalCount =  await CountAsync(filter.Expression);
            return CreateDataPage(pageNumber, pageLength, data, totalCount);
        }

        #endregion

        private readonly OrderBy<TEntity> DefaultOrderBy = new OrderBy<TEntity>(qry => qry.OrderBy(e => e.Id));

        protected IQueryable<TEntity> QueryDb(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes)
        {
            IQueryable<TEntity> query = Db.Set<TEntity>();
            if (filter != null) { query = query.Where(filter); }
            if (includes != null) { query = includes(query); }
            if (orderBy != null) { query = orderBy(query); }
            return query;
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = Db.Set<TEntity>();
            if (filter != null) { query = query.Where(filter); }
            return query.Count();
        }

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = Db.Set<TEntity>();
            if (filter != null) { query = query.Where(filter); }
            return query.CountAsync();
        }        

        public virtual IEnumerable<TEntity> GetPage(int startRow, int pageLength, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            if (orderBy == null) orderBy = DefaultOrderBy.Expression;

            var result = QueryDb(null, orderBy, includes);
            return result.Skip(startRow).Take(pageLength).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetPageAsync(int startRow, int pageLength, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            if (orderBy == null) orderBy = DefaultOrderBy.Expression;
            var result = QueryDb(null, orderBy, includes);
            return await result.Skip(startRow).Take(pageLength).ToListAsync();
        }

        public virtual IEnumerable<TEntity> QueryPage(int startRow, int pageLength, Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            if (orderBy == null) orderBy = DefaultOrderBy.Expression;

            var result = QueryDb(filter, orderBy, includes);
            return result.Skip(startRow).Take(pageLength).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> QueryPageAsync(int startRow, int pageLength, Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            if (orderBy == null) orderBy = DefaultOrderBy.Expression;

            var result = QueryDb(filter, orderBy, includes);
            return await result.Skip(startRow).Take(pageLength).ToListAsync();
        }

        private DataPage<TEntity> CreateDataPage(int pageNumber, int pageLength, IEnumerable<TEntity> data, long totalEntityCount)
        {
            var page = new DataPage<TEntity>()
            {
                Data = data,
                TotalEntityCount = totalEntityCount,
                PageLength = pageLength,
                PageNumber = pageNumber
            };

            return page;
        }
    }    

}
