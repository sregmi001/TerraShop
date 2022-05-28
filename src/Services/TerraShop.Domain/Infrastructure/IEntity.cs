namespace TerraShop.Domain.Infrastructure
{
    public interface IEntity<IdType>
    {
        public IdType Id { get; }
    }
}
