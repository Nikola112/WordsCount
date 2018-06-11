using System.Data.Entity;
using WordsCount.Core.Repositories;

namespace WordsCount.DatabasePersistance.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields

        protected DbContext _context;
        protected IDbSet<TEntity> _entities;

        #endregion

        #region Constructors

        public Repository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        #endregion

        #region Methods
        
        public TEntity Get()
        {
            return _entities.Find(1);
        }

        #endregion
    }
}
