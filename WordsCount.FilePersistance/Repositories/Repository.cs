using WordsCount.Core.Repositories;
using WordsCount.FileFramework;

namespace WordsCount.FilePersistance.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields

        protected FileLoader<TEntity> _context;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public Repository(FileLoader<TEntity> context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public virtual TEntity Get()
        {
            return _context.Value;
        }

        #endregion
    }
}
