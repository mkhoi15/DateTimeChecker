using DateTimeChecker.ServiceContract;
using DateTimeChecker.Services;
using NUnit.Framework;

namespace TestDateTimeChecker
{
	public class Tests
	{
		private IDateTimeService _dateTimeService;

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
		public void CheckDayInMonth_ShouldReturn28_ToBeSuccess()
		{
			var ExpectDay = 28;
			var month = 2;
			var year = 2001;

			var actualValue = _dateTimeService.CheckDayInMonth(month, year);

			Assert.That(actualValue, Is.EqualTo(ExpectDay));
		}

		[Test]
		public void CheckDayInMonth_ShouldReturn0_ToBeSuccess()
		{
			var expectDay = 0;
			var month = 13;
			var year = 2000;

			var actualDay = _dateTimeService.CheckDayInMonth(month, year);

			Assert.That(actualDay, Is.EqualTo(expectDay));
		}
	}
}