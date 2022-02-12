namespace Supervaga.Domain.Shared.Contracts.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public bool Equals(Entity? other)
        {
            return Id == other!.Id;
        }
    }
}