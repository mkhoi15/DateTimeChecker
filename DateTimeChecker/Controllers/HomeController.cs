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
			
            // Check Day
            if(date.Day == null)
            {
                IsError = true;
                ViewBag.DayError = "Day field can not be blank";
            }

			bool IsNumberDay = int.TryParse(date.Day, out int day) ;


			if (IsNumberDay == false)
			{
				IsError = true;
				ViewBag.DayError = "Day field must me a number";
			}

			if (day < 0 || day > 31)
			{
				IsError = true;
				ViewBag.DayError = "Day must be between 1 and 31";
			}

            // Check Month
			if (date.Month == null)
            {
                IsError = true;
                ViewBag.MonthError = "Month field can not be blank";
            }

			
			bool IsNumberMonth = int.TryParse(date.Month, out int month);

			if (IsNumberMonth == false)
			{
				IsError = true;
				ViewBag.MonthError = "Month field must me a number";
			}

			if (month < 0 || month > 12)
			{
				IsError = true;
				ViewBag.MonthError = "Month must be between 1 and 12";
			}

			// Check Year
			if (date.Year == null)
			{
				IsError = true;
				ViewBag.YearError = "Year field can not be blank";
			}

			
			bool IsNumberYear = int.TryParse(date.Year, out int year);

			if (IsNumberYear == false)
			{
				IsError = true;
				ViewBag.YearError = "Year field must me a number";
			}

			if (year < 1000 || year > 3000)
			{
				IsError = true;
				ViewBag.YearError = "Year must be between 1000 and 3000";
			}

			if (IsError)
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
