namespace DataLayer.DAL
{
    public abstract class BaseRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
    }
}
