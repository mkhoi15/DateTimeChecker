namespace DateTimeChecker.ServiceContract
{
    public interface IDateTimeService
    {
        int CheckDayInMonth(int month, int year);
        bool CheckDate(int actualDay, int actualMonth, int actualYear);

	}
}
