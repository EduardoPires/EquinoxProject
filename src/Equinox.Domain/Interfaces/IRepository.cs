using System;
using System.Linq;

namespace Equinox.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
        
        DataPage<TEntity> PagerGet(int pageNumber, int pageLength, OrderBy<TEntity> orderby = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
        Task<DataPage<TEntity>> PagerGetAsync(int pageNumber, int pageLength, OrderBy<TEntity> orderby = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
        DataPage<TEntity> PagerQuery(int pageNumber, int pageLength, Filter<TEntity> filter, OrderBy<TEntity> orderby = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
        Task<DataPage<TEntity>> PagerQueryAsync(int pageNumber, int pageLength, Filter<TEntity> filter, OrderBy<TEntity> orderby = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
    }
    
    //-------------------- To put different corresponding cs files.
       public class ReplaceExpressionVisitor : ExpressionVisitor
    {
        private readonly Expression _oldValue;
        private readonly Expression _newValue;
        public ReplaceExpressionVisitor(Expression oldValue, Expression newValue) { _oldValue = oldValue; _newValue = newValue; }
        public override Expression Visit(Expression node)
        {
            if (node == _oldValue) return _newValue;
            return base.Visit(node);
        }
    }

    public class Filter<TEntity>
    {
        public Filter(Expression<Func<TEntity, bool>> expression) { Expression = expression; }

        public Expression<Func<TEntity, bool>> Expression { get; private set; }

        public void AddExpression(Expression<Func<TEntity, bool>> newExpression)
        {
            if (newExpression == null) throw new ArgumentNullException(nameof(newExpression), $"{nameof(newExpression)} is null.");

            if (Expression == null) Expression = newExpression;

            var parameter = System.Linq.Expressions.Expression.Parameter(typeof(TEntity));

            var leftVisitor = new ReplaceExpressionVisitor(newExpression.Parameters[0], parameter);
            var left = leftVisitor.Visit(newExpression.Body);

            var rightVisitor = new ReplaceExpressionVisitor(Expression.Parameters[0], parameter);
            var right = rightVisitor.Visit(Expression.Body);

            Expression = System.Linq.Expressions.Expression.Lambda<Func<TEntity, bool>>(System.Linq.Expressions.Expression.AndAlso(left, right), parameter);
        }
    }

    //public interface IDataPager<TEntity>
    //{
    //    DataPage<TEntity> Get(int pageNumber, int pageLength, OrderBy<TEntity> orderby = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
    //    DataPage<TEntity> Query(int pageNumber, int pageLength, Filter<TEntity> filter, OrderBy<TEntity> orderby = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);

    //    Task<DataPage<TEntity>> GetAsync(int pageNumber, int pageLength, OrderBy<TEntity> orderby = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
    //    Task<DataPage<TEntity>> QueryAsync(int pageNumber, int pageLength, Filter<TEntity> filter, OrderBy<TEntity> orderby = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
    //}

    public class DataPage<TEntity>
    {
        public IEnumerable<TEntity> Data { get; set; }
        public long TotalEntityCount { get; set; }
        public int PageNumber { get; set; }
        public int PageLength { get; set; }
        public int TotalPageCount { get { return Convert.ToInt32(Math.Ceiling((decimal)TotalEntityCount / PageLength)); } }
    }

    public class OrderBy<TEntity>
    {
        public OrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> expression) { Expression = expression; }
        public OrderBy(string columName, bool reverse) { Expression = GetOrderBy(columName, reverse); }
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> Expression { get; private set; }

        private Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> GetOrderBy(string columnName, bool reverse)
        {
            Type typeQueryable = typeof(IQueryable<TEntity>);
            ParameterExpression argQueryable = System.Linq.Expressions.Expression.Parameter(typeQueryable, "p");
            var outerExpression = System.Linq.Expressions.Expression.Lambda(argQueryable, argQueryable);

            IQueryable<TEntity> query = new List<TEntity>().AsQueryable<TEntity>();
            var entityType = typeof(TEntity);
            ParameterExpression arg = System.Linq.Expressions.Expression.Parameter(entityType, "x");

            Expression expression = arg;
            string[] properties = columnName.Split('.');
            foreach (string propertyName in properties)
            {
                PropertyInfo propertyInfo = entityType.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                expression = System.Linq.Expressions.Expression.Property(expression, propertyInfo);
                entityType = propertyInfo.PropertyType;
            }
            LambdaExpression lambda = System.Linq.Expressions.Expression.Lambda(expression, arg);
            string methodName = reverse ? "OrderByDescending" : "OrderBy";
            MethodCallExpression resultExp = System.Linq.Expressions.Expression.Call(typeof(Queryable), methodName, new Type[] { typeof(TEntity), entityType }, outerExpression.Body, System.Linq.Expressions.Expression.Quote(lambda));
            var finalLambda = System.Linq.Expressions.Expression.Lambda(resultExp, argQueryable);
            return (Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>)finalLambda.Compile();
        }
    }
}
