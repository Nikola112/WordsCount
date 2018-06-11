using WordsCount.Core.Domain;
using WordsCount.Core.Repositories;
using WordsCount.FileFramework;

namespace WordsCount.FilePersistance.Repositories
{
    public class SentenceRepository : Repository<Sentence>, ISentenceRepository
    {
        #region Constructors

        public SentenceRepository(FileLoader<Sentence> context) : base(context)
        {
        }

        #endregion

        #region Methods

        public int GetNumberOfWords() => _context.Value.NumberOfWords;

        public void SetNumberOfWords(int numberOfWords) => _context.Value.NumberOfWords = numberOfWords;

        #endregion
    }
}
