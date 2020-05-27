using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Youtube2.Model;
using Youtube2.Models;
using Youtube2.Services.Implementation;
using Youtube2.ViewModels;

namespace Youtube2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> userManager;
        private ProfileService profileService;
        private VideosService videosService;
        //private List<Videos> videos = new List<Videos>(200);
 

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, 
            ProfileService profileService, VideosService videosService)
        {
            _logger = logger;
            this.userManager = userManager;
            this.profileService = profileService;
            this.videosService = videosService;
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
            var videosVM = new VideosVM
            {
                Index = 0,
                videos = videosService.GetAllVideosOrdered()
            };
            return View(videosVM);
        }

        public IActionResult Profile()
        {
            
            var userId = userManager.GetUserId(HttpContext.User);
            Profile profilSelectat = profileService.GetDetailsById(userId);

            //string username = txtusername.Text;


            var profileVM = new ProfileVM {
                    UserId = userId,
                    Nume = profilSelectat.Nume,
                    Description = profilSelectat.Description,
                    NrDislikes = profilSelectat.NrDislikesT,
                    NrLikes = profilSelectat.NrLikesT,
                    NrSubscribers = profilSelectat.NrSubscribers,
                    Videos = videosService.GetVideosByUserId(userId)
             };

            return View(profileVM);
 }

        public IActionResult Videos()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            Profile profilSelectat = profileService.GetDetailsById(userId);
            var videos = videosService.GetVideosByUserId(userId);

            return View(videos);
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
