namespace CarSupplier.DA.Entities
{
    public interface IEntity
    {
    }

    public interface IEntity<ID> : IEntity
    {
        ID Id { get; }
    }
}