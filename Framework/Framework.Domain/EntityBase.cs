namespace Framework.Domain
{
    public abstract class EntityBase
    {
        protected EntityBase(Guid id)
        {
            this.Id = id;
        }
        public Guid Id { get; private set; }

    }
}