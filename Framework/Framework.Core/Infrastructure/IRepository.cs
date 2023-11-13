
using Framework.Core.Domain;

namespace Framework.Core.Infrastructure
{
    public class IRepository<TAggregateRoot> where  TAggregateRoot:IAggregateRoot
    {
    }
}
