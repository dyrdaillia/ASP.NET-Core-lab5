// Controller (HomeController.cs)
using Microsoft.AspNetCore.Mvc;
using System;

public class HomeController : Controller
{
    [HttpPost]
    public IActionResult SaveData(string valueInput, DateTime dateTimeInput)
    {
        // Записати дані в куки з встановленням дати старіння
        Response.Cookies.Append("MyData", $"{valueInput} - {dateTimeInput}", new Microsoft.AspNetCore.Http.CookieOptions
        {
            Expires = dateTimeInput // Встановлення дати старіння
        });

        return RedirectToAction("Index");
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CheckCookies()
    {
        var myData = Request.Cookies["MyData"];
        ViewData["MyData"] = myData;
        return View();
    }
}
