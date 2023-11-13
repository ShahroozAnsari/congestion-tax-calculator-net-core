
namespace Domain.TollFees.Services
{
    public interface ITollFeeOverlapChecker
    {
       bool HaveOverlap(Guid id, int year, TimeOnly from, TimeOnly to);
    }
}
