using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Youtube2.Model;
using Youtube2.Services.Implementation;

namespace Youtube2.Controllers
{
    public class ProfilesController : Controller
    {
        //private readonly ProfileDBContext _context;
        private readonly ProfileService profileService;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public ProfilesController(ProfileService context, UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            profileService = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // GET: Profiles
        public async Task<IActionResult> Index()
        {
            var profiles = profileService.GetAllProfiles();
            return View(profiles);
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = profileService.GetDetailsById(id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            ViewData["SubscriptionId"] = new SelectList(profileService.GetAllSubbs(), "SubscriptionId", "SubscriptionId");
            return View();
        }

        public ViewResult Home()
        {
            return View();
        }
            
        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfileId,Nume,MailAdress,Description,Password,NrLikesT,NrDislikesT,NrSubscribers,SubscriptionId")] Profile profile)
        {
            var user = new IdentityUser { UserName = profile.MailAdress, Email = profile.MailAdress };

            var result = await userManager.CreateAsync(user, profile.Password);
            var userId = user.Id;
            profile.ProfileId = user.Id;

            if (ModelState.IsValid)
            {
                await userManager.AddToRoleAsync(user, "User");
                profileService.Create(profile);
                return RedirectToAction(nameof(Home));
            }

            return View();
        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = profileService.GetDetailsById(id);

            if (profile == null)
            {
                return NotFound();
            }
            ViewData["SubscriptionId"] = new SelectList(profileService.GetAllSubbs(), "SubscriptionId", "SubscriptionId", profile.ProfileId);
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProfileId,Nume,Description,NrLikesT,NrDislikesT,NrSubscribers,SubscriptionId")] Profile profile)
        {
            if (id != profile.ProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    profileService.UpdateProfile(profile);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!profileService.ProfileExists(profile.ProfileId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubscriptionId"] = new SelectList(profileService.GetAllSubbs(), "SubscriptionId", "SubscriptionId", profile.ProfileId);
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = profileService.GetDetailsById(id);

            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            profileService.DeleteProfile(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
