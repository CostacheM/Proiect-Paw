using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Youtube2.Model;
using Youtube2.Models;
using Youtube2.Services.Implementation;

namespace Youtube2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> userManager;
        //var db = Youtube-Datapase.Open("WebPagesMovies");
        //var selectedData = db.Query("SELECT * FROM Movies");
        //var grid = new WebGrid(source: selectedData);
        private ProfileService profileService;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, ProfileService profileService)
        {
            _logger = logger;
            this.userManager = userManager;
            this.profileService = profileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Subscription()
        {
            return View();
        }

        public IActionResult Tranding()
        {
            return View();
        }

        public IActionResult Profile()
        {
            ViewBag.userid = userManager.GetUserId(HttpContext.User);
            Profile profilSelectat = profileService.GetDetailsById(ViewBag.userid);
            ViewBag.Nume = profilSelectat.Nume;
            ViewBag.Descriere = profilSelectat.Description;
            ViewBag.NrL = profilSelectat.NrLikesT;
            ViewBag.NrD = profilSelectat.NrDislikesT;
            ViewBag.Subs = profilSelectat.NrSubscribers;
            return View();
        }

        public IActionResult Privacy()
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
