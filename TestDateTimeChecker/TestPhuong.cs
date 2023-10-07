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
        public void Test_Day_In_Month6_Year2020()
        {
            int? day = 6;
            int? month = 2020;
            int expectedValue = 30;
            //test result
            int dayReturn = _dateTimeService.CheckDayInMonth(day, month);
            //compare
            Assert.That(expectedValue, Is.EqualTo(dayReturn));
        }
        [Test]
        public void Test_Day_In_Month1_Year10()
        {
            int expectedValue = 31;
            int dayReturn = _dateTimeService.CheckDayInMonth(1, 2000);
            Assert.That(expectedValue, Is.EqualTo(dayReturn));
        }
        [Test]
        public void Test_Day_In_Month13_Year2021()
        {
            int? day = 13;
            int? month = 2021; 
            int expectedValue = 0;
            //test result
            int dayReturn = _dateTimeService.CheckDayInMonth(day, month);
            //compare
            Assert.That(expectedValue, Is.EqualTo(dayReturn));
        }
        [Test]
        public void Test_Day_In_MonthNull_Year2021()
        {
            int? day = null;
            int? month = 2021;
            int expectedValue = 0;
            //test result
            int dayReturn = _dateTimeService.CheckDayInMonth(day, month);
            //compare
            Assert.That(expectedValue, Is.EqualTo(dayReturn));
        }
    }
}
