using DateTimeChecker.Model;
using DateTimeChecker.ServiceContract;
using DateTimeChecker.Services;

namespace TestDateTimeChecker
{
	public class Tests5
	{
		private IDateTimeService _dateTimeService;

		[SetUp]
		public void Setup()
		{
			_dateTimeService = new DateTimeService();
		}

        [Test]
        public void TestNonExistDate()
        {
            var ExpectDay = 29;
            var month = 2;
            var year = 2009;

            var actualValue = _dateTimeService.CheckDayInMonth(month, year);
            Assert.That(actualValue, Is.Not.EqualTo(ExpectDay));
        }

        [Test]
        public void TestDateMonthOutOfRange()
        {
            var day = 1;
            var month = 13;
            var year = 2020;

            var isValidDate = _dateTimeService.CheckDate(day, month, year);
            Assert.That(isValidDate, Is.False);
        }

        
        [Test]
        public void TestDate()
        {
			var day = 29;
			var month = 2;
			var year = 4000;

			var isValidDate = _dateTimeService.CheckDate(day, month, year);

            Assert.Throws<ArgumentException>(() => isValidDate.CompareTo(year));
        }

        [Test]
        public void TestMinusDay()
        {
            var day = -1;
            var month = 2;
            var year = 2023;

            var isValidDate = _dateTimeService.CheckDate(-day, month, year);
            Assert.That(isValidDate, Is.False);
        }
    }
}