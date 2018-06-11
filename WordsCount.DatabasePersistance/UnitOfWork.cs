using System;
using WordsCount.Core;
using WordsCount.Core.Repositories;
using WordsCount.DatabasePersistance.Repositories;

namespace WordsCount.DatabasePersistance
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private WordsCountDbContext _context;

        #endregion

        #region Properties

        public ISentenceRepository Sentences { get; private set; }

        #endregion

        #region Constructors

        public UnitOfWork(WordsCountDbContext context)
        {
            _context = context;
            Sentences = new SentenceRepository(_context);
        }

        #endregion

        #region Methods

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        #endregion
    }
}
