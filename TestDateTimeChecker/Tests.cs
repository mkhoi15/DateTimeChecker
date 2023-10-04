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

		#region CheckDayInMonth
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
		#endregion

		#region CheckDate
		[Test]
		public void CheckDate_DayIsNull_TobeFalse()
		{
			int? day = null;
			var month = 2;
			var year = 2000;

			var isValidDate = _dateTimeService.CheckDate(day, month, year);

			Assert.That(isValidDate, Is.False);
		}

		[Test]
		public void CheckDate_MonthIsNull_ToBeFalse()
		{
			int? day = 15;
			int? month = null;
			var year = 2000;

			var isValidDate = _dateTimeService.CheckDate(day, month, year);

			Assert.That(isValidDate, Is.False);
		}

		[Test]
		public void CheckDate_YearIsNull_ToBeFalse()
		{
			int? day = 15;
			int? month = 2;
			int? year = null;

			var isValidDate = _dateTimeService.CheckDate(day, month, year);

			Assert.That(isValidDate, Is.False);
		}

		#endregion
	}
}