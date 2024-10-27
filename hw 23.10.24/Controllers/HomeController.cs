using hw_23._10._24.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace hw_23._10._24.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutMe()
        {
            ViewBag.FirstName = "Yehor";
            ViewBag.LastName = "Kliushyn";
            ViewBag.Gender = "Male";
            ViewBag.Nationality = "Ukrainian";
            ViewBag.Email = "egorka231231@gmail.com";
            ViewBag.GitHub = " https://github.com/loxx3450";

			ViewBag.Languages = new string[]
			{
				"Ukrainian",
				"Russian",
				"German",
				"English"
			};

			ViewBag.ProgrammingLanguages = new string[]
            {
                "C#", 
                "C++", 
                "PHP", 
                "JS"
            };

            ViewBag.Technologies = new string[]
            {
                "PostgreSQL + MySQL + SqlServer",
                "Unity",
                "HTML + CSS",
                "Docker"
            };


			return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
