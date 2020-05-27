using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube2.Model;

namespace Youtube2.ViewModels
{
    public class ProfileVM
    {
        //ViewBag.userid = userManager.GetUserId(HttpContext.User);
        //Profile profilSelectat = profileService.GetDetailsById(ViewBag.userid);
        //ViewBag.Nume = profilSelectat.Nume;
        //ViewBag.Descriere = profilSelectat.Description;
        //ViewBag.NrL = profilSelectat.NrLikesT;
        //ViewBag.NrD = profilSelectat.NrDislikesT;
        //ViewBag.Subs = profilSelectat.NrSubscribers;

        public string UserId { get; set; }
        public string Nume { get; set; }
        public string Description { get; set; }
        public int NrLikes { get; set; }
        public int NrDislikes { get; set; }
        public int NrSubscribers { get; set; }
        public List<Videos> Videos { get; set; }
    }
}
