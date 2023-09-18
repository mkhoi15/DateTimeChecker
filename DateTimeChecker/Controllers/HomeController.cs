using DateTimeChecker.Model;
using DateTimeChecker.ServiceContract;
using Microsoft.AspNetCore.Mvc;

namespace DateTimeChecker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDateTimeService _dateTimeService;

        public HomeController(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        [Route("/")]
        [Route("/home")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/checkday")]
        public IActionResult CheckDay(Date date)
        {
            bool IsError = false;
            int day = 0;
            int month = 0;
            int year = 0;
            bool IsNumberDay = int.TryParse(date.Day, out day);
            bool IsNumberMonth = int.TryParse(date.Month, out month);
            bool IsNumberYear = int.TryParse(date.Year, out year);
            if(IsNumberDay == false )
            {
                IsError = true;
                ViewBag.DayError = "This field must me a number";      
            }
            if (IsNumberMonth == false)
            {
                IsError = true;
                ViewBag.MonthError = "This field must me a number";
            }
            if (IsNumberYear == false)
            {
                IsError = true;
                ViewBag.YearError = "This field must me a number";
            }

            if(IsError == true)
            {
                return View("Index");
            }

            var totalDayInMonth = _dateTimeService.CheckDayInMonth(month, year);
            if (totalDayInMonth == 0 || day > totalDayInMonth)
            {
                ViewBag.Result = $"{date} is Not correct date time!";
                return View();
            }
            ViewBag.Result = $"{date} is correct day time!";
            return View(date);
        }
    }
}
