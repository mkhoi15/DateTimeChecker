using DateTimeChecker.Model;
using DateTimeChecker.ServiceContract;
using Microsoft.AspNetCore.Mvc;
using System;

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

            if(date.Day == null)
            {
                IsError = true;
                ViewBag.DayError = "Day field can not be blank";
            }

            if (date.Month == null)
            {
                IsError = true;
                ViewBag.MonthError = "Month field can not be blank";
            }

            if (date.Year == null)
            {
                IsError = true;
                ViewBag.YearError = "Year field can not be blank";
            }

            if(IsError)
            {
                return View("Index");
            }

            bool IsNumberDay = int.TryParse(date.Day, out int day);
            bool IsNumberMonth = int.TryParse(date.Month, out int month);
            bool IsNumberYear = int.TryParse(date.Year, out int year);
            if(IsNumberDay == false)
            {
                IsError = true;
                ViewBag.DayError = "Day field must me a number";      
            }

            if (IsNumberMonth == false)
            {
                IsError = true;
                ViewBag.MonthError = "Month field must me a number";
            }
            if (IsNumberYear == false)
            {
                IsError = true;
                ViewBag.YearError = "Year field must me a number";
            }

            if(IsError)
            {
                return View("Index");
            }

            if(day < 0 || day > 31)
            {
                IsError = true;
                ViewBag.DayError = "Day must be between 1 and 31";
            }

            if (month < 0 || month > 12)
            {
				IsError = true;
				ViewBag.MonthError = "Month must be between 1 and 12";
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
            //var totalDayInMonth = _dateTimeService.CheckDayInMonth(month, year);
            //if (totalDayInMonth == 0 || day > totalDayInMonth)
            //{
            //	ViewBag.Result = $"{date} is Not correct date time!";
            //	return View();
            //}
            //ViewBag.Result = $"{date} is correct date time!";
            bool isValidDate = _dateTimeService.CheckDate(day, month, year);
            if (isValidDate == false) {
				ViewBag.Result = $"{date} is Not correct date time!";
                return View(date);
			}
			ViewBag.Result = $"{date} is correct date time!";
			return View(date);
        }

    }
}
