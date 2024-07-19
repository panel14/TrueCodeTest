namespace TrueCodeTest.Domain.Entities.Abstractions
{
    public abstract class EntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
