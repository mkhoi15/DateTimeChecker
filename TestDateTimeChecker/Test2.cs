using DateTimeChecker.ServiceContract;
using DateTimeChecker.Services;

namespace TestDateTimeChecker
{
	public class Test2
	{
		private  IDateTimeService _dateTimeService;

		[SetUp]
		public void Setup()
		{
			_dateTimeService = new DateTimeService();
		}


		[Test]
		public void CheckDayInMonth_ShouldReturn28_ToBeFaile()
		{
			var ExpectDay = 29;
			var month = 2;
			var year = 2001;

			var actualValue = _dateTimeService.CheckDayInMonth(month, year);

			Assert.That(actualValue, Is.Not.EqualTo(ExpectDay));
		}

		[Test]
		public void CheckDayInMonth_ShouldReturn29_ToBeSuccess()
		{
			var day = 29;
			var month = 2;
			var year = 2000;

			var actualValue = _dateTimeService.CheckDate(day, month, year);

			Assert.That(actualValue, Is.True);
		}

		[Test]
		public void CheckDayInMonth_ShouldReturn31_ToBeSuccess()
		{
			var day = 31;
			var month = 1;
			var year = 2000;

			var actualValue = _dateTimeService.CheckDate(day, month, year);

			Assert.That(actualValue, Is.True);
		}


		[Test]
		public void CheckDayInMonth_MonthIsNull_ShouldReturn0()
		{
			var day = 30;
			int? month = null;
			var year = 2000;

			var actualValue = _dateTimeService.CheckDate(day, month, year);



		}

	}
}
