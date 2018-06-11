using WordsCount.Core;
using WordsCount.Core.Domain;
using WordsCount.Core.Repositories;
using WordsCount.FileFramework;
using WordsCount.FilePersistance.Repositories;

namespace WordsCount.FilePersistance
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private FileLoader<Sentence> _context;

        #endregion

        #region Properties

        public ISentenceRepository Sentences { get; private set; }

        #endregion

        #region Constructors

        public UnitOfWork(FileLoader<Sentence> context)
        {
            _context = context;
            Sentences = new SentenceRepository(_context);
        }

        #endregion

        #region Methods

        public int Complete()
        {
            _context.SaveValue();
            return 0;
        }

        public void Dispose()
        {
            // Nothing to dispose
        }

        #endregion

        

       
    }
}
