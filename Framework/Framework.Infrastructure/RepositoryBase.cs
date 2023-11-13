

using Framework.Core.Domain;
using Framework.Core.Infrastructure;

namespace Framework.Infrastructure
{
    public abstract class RepositoryBase<TAggregateRoot>: IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
    }
}
