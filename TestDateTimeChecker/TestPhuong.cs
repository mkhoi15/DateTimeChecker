using DateTimeChecker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDateTimeChecker
{
    public class TestPhuong
    {
        private DateTimeService _dateTimeService;
        [SetUp]
        public void Setup()
        {
            _dateTimeService = new DateTimeService();
        }

        [Test]
        public void Test_Day_In_Month_1()
        {
            int expectedValue = 30;
            int dayReturn = _dateTimeService.CheckDayInMonth(6, 2020);
            Assert.That(expectedValue, Is.EqualTo(dayReturn));
        }
        [Test]
        public void Test_Day_In_Month_2()
        {
            int expectedValue = 31;
            int dayReturn = _dateTimeService.CheckDayInMonth(1, 2000);
            Assert.That(expectedValue, Is.EqualTo(dayReturn));
        }
        [Test]
        public void Test_Day_In_Month_3()
        {
            int expectedValue = 0;
            int dayReturn = _dateTimeService.CheckDayInMonth(13, 2021);
            Assert.That(expectedValue, Is.EqualTo(dayReturn));
        }
        [Test]
        public void Test_Day_In_Month_4()
        {
            int expectedValue = 0;
            int dayReturn = _dateTimeService.CheckDayInMonth(null, 2021);
            Assert.That(expectedValue, Is.EqualTo(dayReturn));
        }
    }
}
