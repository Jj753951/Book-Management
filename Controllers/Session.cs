using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace Book_Management.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetSession()
        {
            var username = HttpContext.Session.GetString("Iwan Iwanow");
            HttpContext.Session.SetString("UserName", "Iwan Iwanow");
            HttpContext.Session.SetString("SessionStartTime", DateTime.Now.ToString());
            return Content($"Сесията е съзададена успешно. Потребител: Iwan Iwanow");
        }

        public IActionResult GetSession()
        {
            var username = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(username))
            {
                return Content("Няма активна сесия");
            }

            DateTime sessionStartTime = DateTime.Parse(HttpContext.Session.GetString("SessionStartTime"));
            if (sessionStartTime.AddMinutes(1) < DateTime.Now)
            {
                ClearSession();
                return Content("Сесията ви е изтекла");
            }

            return Content($"Сесията е съзададена успешно. Потребител: {username}");
        }

        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return Content("Сесията беше изтрита");
        }

        public IActionResult CheckSessionStatus()
        {
            var sessionStart = HttpContext.Session.GetString("SessionStartTime");

            if (string.IsNullOrEmpty(sessionStart))
            {
                return Content("Няма активна сесия");
            }

            DateTime sessionStartTime = DateTime.Parse(sessionStart);
            if (sessionStartTime.AddMinutes(1) < DateTime.Now)
            {
                return Content("Сесията ви е изтекла");
            }

            return Content("Сесията е активна");
        }
    }
}
