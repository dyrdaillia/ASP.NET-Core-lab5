// Controller (HomeController.cs)
using Microsoft.AspNetCore.Mvc;
using System;

public class HomeController : Controller
{
    [HttpPost]
    public IActionResult SaveData(string valueInput, DateTime dateTimeInput)
    {
        // �������� ��� � ���� � ������������� ���� �������
        Response.Cookies.Append("MyData", $"{valueInput} - {dateTimeInput}", new Microsoft.AspNetCore.Http.CookieOptions
        {
            Expires = dateTimeInput // ������������ ���� �������
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
