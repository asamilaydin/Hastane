using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hastane.Models;
using Hastane.Services;
using Microsoft.AspNetCore.Localization;
using System.Text.RegularExpressions;

namespace Hastane.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private LanguageService _localization;

    public HomeController(ILogger<HomeController> logger, LanguageService localization)
    {
        _logger = logger;
        _localization = localization;
    }


    public IActionResult Index()
    {

        ViewBag.deneme = _localization.Getkey("deneme").Value;

        var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
        return View();
    }
    public IActionResult DilDegistir(string Culture)
    {

        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(Culture)), new CookieOptions()
        {
            Expires = DateTimeOffset.UtcNow.AddYears(1)
        });
        return Redirect(Request.Headers["Referer"].ToString());

    }
  

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult AccessDenied()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

