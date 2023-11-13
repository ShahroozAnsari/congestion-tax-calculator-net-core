using Domain.TollFees.Services;
using Framework.Core.Domain;
using Framework.Domain;

namespace Domain.TollFees
{
    public class TollFee : EntityBase, IAggregateRoot
    {
        public TollFee(ITollFeeOverlapChecker tollFeeOverlapChecker,
            int year, 
            TimeOnly from,         
            TimeOnly to)
            :base(Guid.NewGuid())
        {
           
            Year = year;
            From = from;
            To = to;
            if (tollFeeOverlapChecker.HaveOverlap(Id, year, from, to)){
                throw new TollFeeHaveOverlapsException();
            }
         

        }
        public int Year { get; private set; }
        public TimeOnly From { get; private set; }
        public TimeOnly To { get; private set; }

    }
}
