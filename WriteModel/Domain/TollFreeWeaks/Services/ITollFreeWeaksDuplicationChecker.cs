namespace Domain.TollFreeWeaks.Services
{
    public interface ITollFreeWeaksDuplicationChecker
    {
        public bool IsDuplicate(int year, DayOfWeek dayOfWeek);
    }
}
