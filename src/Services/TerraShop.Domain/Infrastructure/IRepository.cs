namespace TerraShop.Domain.Infrastructure
{
    public interface IRepository<T, IdType> where T : IEntity<IdType>
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T?> GetAsync(IdType id);
        Task SaveAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
