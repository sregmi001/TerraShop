namespace TerraShop.Domain.Infrastructure
{
    public interface IRepository<T, IdType> where T : IEntity<IdType>
    {
        Task<ICollection<T>> GetAll();
        Task<T> Get(IdType id);
        Task SaveAsync(T entity);
        Task Remove(T entity);
    }
}
