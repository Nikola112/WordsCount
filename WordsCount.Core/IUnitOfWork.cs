using System;
using WordsCount.Core.Repositories;

namespace WordsCount.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ISentenceRepository Sentences { get; }

        int Complete();
    }
}
