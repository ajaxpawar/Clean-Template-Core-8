namespace Domain.Common
{
    // Base class for all domain entities
    public abstract class Entity
    {
        // Unique identifier for the entity
        public Guid Id { get; set; }

        // List to track domain events for the entity
        protected readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        // Constructor to create entity with a specified ID
        protected Entity(Guid id)
        {
            Id = id;
        }

        // Retrieves and clears the list of domain events
        public List<IDomainEvent> PopDomainEvents()
        {
            var copy = _domainEvents.ToList(); // Copy current events
            _domainEvents.Clear(); // Clear original event list
            return copy; // Return the copied events
        }

        // Parameterless constructor for flexibility in derived classes
        protected Entity() { }
    }
}
