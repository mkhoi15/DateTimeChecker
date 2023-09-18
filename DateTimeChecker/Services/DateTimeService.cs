using DateTimeChecker.ServiceContract;

namespace DateTimeChecker.Services
{
    public class DateTimeService : IDateTimeService
    {
        public int CheckDayInMonth(int month, int year)
        {
            switch(month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;

                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;

                case 2:
                    if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                    {
                        return 29;
                    }
                    return 28;

                default: return 0;
            }
        }
    }
}
