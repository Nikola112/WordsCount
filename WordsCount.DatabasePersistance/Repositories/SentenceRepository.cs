using WordsCount.Core.Domain;
using WordsCount.Core.Repositories;

namespace WordsCount.DatabasePersistance.Repositories
{
    public class SentenceRepository : Repository<Sentence>, ISentenceRepository
    {
        #region Properties

        public WordsCountDbContext WordsCountDbContext
        {
            get => _context as WordsCountDbContext;
        }

        #endregion

        #region Constructors

        public SentenceRepository(WordsCountDbContext context) : base(context)
        {
        }

        #endregion

        #region Methods

        public int GetNumberOfWords() => WordsCountDbContext.Sentences.Find(1).NumberOfWords;

        public void SetNumberOfWords(int numberOfWords) => WordsCountDbContext.Sentences.Find(1).NumberOfWords = numberOfWords;

        #endregion
    }
}
