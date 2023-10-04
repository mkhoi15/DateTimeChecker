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

		#region CheckDayInMonth

		[Test] //1
		public void CheckDayInMonth_ShouldReturn31_ToBeSuccess()
		{
			var ExpectDay = 31;
			var month = 1;
			var year = 2000;

			var actualValue = _dateTimeService.CheckDayInMonth(month, year);

			Assert.That(actualValue, Is.EqualTo(ExpectDay));
		}

		[Test] //2
		public void CheckDayInMonth_ShouldReturn28_ToBeSuccess()
		{
			var ExpectDay = 28;
			var month = 2;
			var year = 2021;

			var actualValue = _dateTimeService.CheckDayInMonth(month, year);

			Assert.That(actualValue, Is.EqualTo(ExpectDay));
		}
	

		[Test] //3
		public void CheckDayInMonth_ShouldReturn29_ToBeSuccess()
		{
			var ExpectDay = 29;
			var month = 2;
			var year = 2020;

			var actualValue = _dateTimeService.CheckDayInMonth(month, year);

			Assert.That(actualValue, Is.EqualTo(ExpectDay));
		}

		[Test] // Chưa có trên lab2
		public void CheckDayInMonth_ShouldReturn28_ToBeFail()
		{
			var ExpectDay = 29;
			var month = 2;
			var year = 2001;

			var actualValue = _dateTimeService.CheckDayInMonth(month, year);

			Assert.That(actualValue, Is.Not.EqualTo(ExpectDay));
		}


		[Test] //4
		public void CheckDayInMonth_MonthIsNull_ShouldReturn0()
		{
			var day = 30;
			int? month = null;
			var year = 2000;

			var actualValue = _dateTimeService.CheckDayInMonth(month, year);

			Assert.That(actualValue, Is.EqualTo(day));

		}

		[Test] //5
		public void CheckDayInMonth_ShouldReturn30_ToBeSuccess()
		{
			var ExpectDay = 30;
			var month = 6;
			var year = 2020;

			var actualValue = _dateTimeService.CheckDayInMonth(month, year);

			Assert.That(actualValue, Is.EqualTo(ExpectDay));
		}

		[Test] //6
		public void CheckDayInMonth_YearIsOutOfRange_ShouldReturn0()
		{
			var day = 30;
			var month = 1;
			int? year = null;

			var actualValue = _dateTimeService.CheckDate(day, month, year);

			Assert.False(actualValue);

		}

		#endregion

		#region CheckDate

		[Test]
		public void CheckDate_ShouldReturnTrue_ToBeSuccess()
		{
			var day = 29;
			var month = 2;
			var year = 2000;

			var actualValue = _dateTimeService.CheckDate(day, month, year);

			Assert.That(actualValue, Is.True);
		}
		
		#endregion

	}
}
