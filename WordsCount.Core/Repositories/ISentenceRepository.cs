using WordsCount.Core.Domain;

namespace WordsCount.Core.Repositories
{
     public interface ISentenceRepository : IRepository<Sentence>
    {
        int GetNumberOfWords();
        void SetNumberOfWords(int numberOfWords);
    }
}
