using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

public class AccountController : Controller
{
    private const string CookieKey = "RememberMeUser";

    public IActionResult Login()
    {
        var model = new LoginViewModel
        {
            Username = Request.Cookies[CookieKey] // Автоматично попълване на потребителското име от бисквитката
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Тук добави проверка за валидност на потребителя (примерно срещу база данни)

            if (model.RememberMe)
            {
                // Създаване на бисквитка, валидна за 30 дни
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddDays(30),
                    HttpOnly = true
                };
                Response.Cookies.Append(CookieKey, model.Username, options);
            }
            else
            {
                Response.Cookies.Delete(CookieKey); // Изтриване на бисквитката, ако не е избрано "Запомни ме"
            }

            return RedirectToAction("Index", "Home");
        }
        return View(model);
    }
}
