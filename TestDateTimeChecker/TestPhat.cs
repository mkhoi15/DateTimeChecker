using DateTimeChecker.ServiceContract;
using DateTimeChecker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDateTimeChecker
{
    internal class TestPhat
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
        public void CheckDayInMonth_SpecialMonth_ShouldReturn29_ToBeSuccess()
        {
            var ExpectDay = 29;
            var month = 2;
            var year = 2020;

            var actualValue = _dateTimeService.CheckDayInMonth(month, year);

            Assert.That(actualValue, Is.EqualTo(ExpectDay));
        }
        [Test]
        public void CheckDayInMonth_OddMonth_ShouldReturn31_ToBeSuccess()
        {
            var ExpectDay = 31;
            var month = 1;
            var year = 2020;

            var actualValue = _dateTimeService.CheckDayInMonth(month, year);

            Assert.That(actualValue, Is.EqualTo(ExpectDay));

        }
    }
}
