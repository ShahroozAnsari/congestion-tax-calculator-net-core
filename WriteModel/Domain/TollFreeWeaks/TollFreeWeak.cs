
using Domain.TollFreeWeaks.Exceptions;
using Domain.TollFreeWeaks.Services;
using Framework.Core.Domain;
using Framework.Domain;

namespace Domain.TollFreeWeaks
{
    public class TollFreeWeak : EntityBase, IAggregateRoot
    {
        public TollFreeWeak(ITollFreeWeaksDuplicationChecker tollFreeDuplicationChecker,
            int year,
            DayOfWeek dayOfWeek) : base(Guid.NewGuid())
        {
            Year = year;
            DayOfWeek = dayOfWeek;
            if (tollFreeDuplicationChecker.IsDuplicate(year, dayOfWeek))
            {
                throw new TollFreeWeakIsDuplicate();
            }
        }
        public int Year { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }
    }
}
