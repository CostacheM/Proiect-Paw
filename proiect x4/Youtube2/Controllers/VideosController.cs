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
    public class VideosController : Controller
    {
        private readonly VideosService videoService;

        public VideosController(VideosService videoService)
        {
            this.videoService = videoService;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            var video = videoService.GetAllVideos();
            return View(video);
        }

        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videos = videoService.GetDetailsById(id);

            if (videos == null)
            {
                return NotFound();
            }

            return View(videos);
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            ViewData["ProfileId"] = new SelectList(videoService.GetAllProfiles(), "ProfileId", "ProfileId");
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideosId,ProfileId,NrLikes,NrDislikes,NrComments,Video,Type")] Videos videos)
        {
            if (ModelState.IsValid)
            {
                videoService.Create(videos);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfileId"] = new SelectList(videoService.GetAllProfiles(), "ProfileId", "ProfileId");
            return View(videos);
        }

        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videos = videoService.GetDetailsById(id);

            if (videos == null)
            {
                return NotFound();
            }
            ViewData["ProfileId"] = new SelectList(videoService.GetAllProfiles(), "ProfileId", "ProfileId");
            return View(videos);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideosId,ProfileId,NrLikes,NrDislikes,NrComments,Video,Type")] Videos videos)
        {
            if (id != videos.VideosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    videoService.UpdateVideos(videos);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!videoService.VideosExists(videos.VideosId))
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
            ViewData["ProfileId"] = new SelectList(videoService.GetAllProfiles(), "ProfileId", "ProfileId");
            return View(videos);
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videos = videoService.GetDetailsById(id);

            if (videos == null)
            {
                return NotFound();
            }

            return View(videos);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            videoService.DeleteVideos(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
