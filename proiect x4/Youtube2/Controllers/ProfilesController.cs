using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ProfilesController(ProfileService context)
        {
            profileService = context;
        }

        // GET: Profiles
        public async Task<IActionResult> Index()
        {
            var profiles = profileService.GetAllProfiles();
            return View(profiles);
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfileId,Nume,Description,NrLikesT,NrDislikesT,NrSubscribers,SubscriptionId")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                profileService.Create(profile);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubscriptionId"] = new SelectList(profileService.GetAllSubbs(), "SubscriptionId", "SubscriptionId", profile.ProfileId);
            return View(profile);
        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(int id, [Bind("ProfileId,Nume,Description,NrLikesT,NrDislikesT,NrSubscribers,SubscriptionId")] Profile profile)
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
        public async Task<IActionResult> Delete(int? id)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            profileService.DeleteProfile(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
