namespace WordsCount.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get();
    }
}
