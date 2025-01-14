using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Initialise counter if NULL
            if (HttpContext.Session.GetInt32("counter") == null)
            {
                HttpContext.Session.SetInt32("counter", 0);
            }
            
            ViewData["Counter"] = HttpContext.Session.GetInt32("counter");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Increment()
        {
            int counter = HttpContext.Session.GetInt32("counter") ?? 0;
            counter++;
            
            HttpContext.Session.SetInt32("counter", counter);

            ViewData["Counter"] = counter;
            return PartialView("_CounterPartial");
        }

        [HttpPost]
        public IActionResult ReverseString(string stringToReverse)
        {
            // Error if null, empty or white-space (HTML5 validation should prevent errors, but better safe than sorry!)
            if (string.IsNullOrWhiteSpace(stringToReverse))
            {
                ViewData["Error"] = "Please enter a valid string";
                return PartialView("_ReverseStringPartial");
            }
            
            // Reverse characters in string
            char[] charArray = stringToReverse.ToCharArray();
            Array.Reverse(charArray);
            ViewData["StringCharacterReverse"] = new string(charArray);
            
            // Reverse words in string
            IEnumerable<string> words = stringToReverse.Split(' ').Reverse();
            ViewData["StringSentenceReverse"] = string.Join(" ", words);
            
            return PartialView("_ReverseStringPartial");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
