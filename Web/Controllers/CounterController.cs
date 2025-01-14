using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class CounterController : Controller
{
    // GET
    public IActionResult Index()
    {
        int counter = HttpContext.Session.GetInt32("counter") ?? 0;
        ViewData["Counter"] = counter;
        return View();
    }
}