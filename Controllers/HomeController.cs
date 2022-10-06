using ECF_auto_ecole.Models;
using ECF_auto_ecole.SQL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECF_auto_ecole.Controllers
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
            Select selection = new Select();
            List<Eleve> list = new List<Eleve>();
            //list = selection.SelectionEleve();
            return View(list);
        }

        public IActionResult Rendez_vous()
        {
            return View();
        }

        public IActionResult Calendrier()
        {
            return View();
        }

        public IActionResult Historique()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}