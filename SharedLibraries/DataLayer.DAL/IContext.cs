namespace DataLayer.DAL
{
    public interface IContext
    {
        IRepository<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}
