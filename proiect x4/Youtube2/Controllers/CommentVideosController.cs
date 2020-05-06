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
    public class CommentVideosController : Controller
    {
        //private readonly ProfileDBContext _context;
        private readonly CommentVideoService commentVideoService;

        public CommentVideosController(CommentVideoService context)
        {
            commentVideoService = context;
        }

        // GET: CommentVideos
        public async Task<IActionResult> Index()
        {
            var commentVideos = commentVideoService.GetAllCommentVideo();
            return View(commentVideos);
        }

        // GET: CommentVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentVideo = commentVideoService.GetDetailsById(id);
            if (commentVideo == null)
            {
                return NotFound();
            }

            return View(commentVideo);
        }

        // GET: CommentVideos/Create
        public IActionResult Create()
        {
            ViewData["VideosId"] = new SelectList(commentVideoService.GetAllVideos(), "VideosId", "VideosId");
            return View();
        }

        // POST: CommentVideos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentVideoId,VideosId,Comment,NrLikes,NrDislikes")] CommentVideo commentVideo)
        {
            if (ModelState.IsValid)
            {
                commentVideoService.Create(commentVideo);
                return RedirectToAction(nameof(Index));
            }
            ViewData["VideosId"] = new SelectList(commentVideoService.GetAllVideos(), "VideosId", "VideosId", commentVideo.VideosId);
            return View(commentVideo);
        }

        // GET: CommentVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentVideo = commentVideoService.GetDetailsById(id);

            if (commentVideo == null)
            {
                return NotFound();
            }
            ViewData["VideosId"] = new SelectList(commentVideoService.GetAllVideos(), "VideosId", "VideosId", commentVideo.VideosId);
            return View(commentVideo);
        }

        // POST: CommentVideos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentVideoId,VideosId,Comment,NrLikes,NrDislikes")] CommentVideo commentVideo)
        {
            if (id != commentVideo.CommentVideoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    commentVideoService.UpdateCommentVideo(commentVideo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!commentVideoService.CommentVideoExists(commentVideo.CommentVideoId))
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
            ViewData["VideosId"] = new SelectList(commentVideoService.GetAllVideos(), "VideosId", "VideosId", commentVideo.VideosId);

            return View(commentVideo);
        }

        // GET: CommentVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentVideo = commentVideoService.GetDetailsById(id);

            if (commentVideo == null)
            {
                return NotFound();
            }

            return View(commentVideo);
        }

        // POST: CommentVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            commentVideoService.DeleteCommentVideo(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
