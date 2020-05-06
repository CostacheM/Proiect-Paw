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
    public class CommentChannelsController : Controller
    {
        //private readonly ProfileDBContext _context;
        private readonly CommentChannelService commentChannelService;

        public CommentChannelsController(CommentChannelService context)
        {
            commentChannelService = context;
        }

        // GET: CommentChannels
        public async Task<IActionResult> Index()
        {
            var commentChannels = commentChannelService.GetAllCommentChannel();
            return View(commentChannels);
        }

        // GET: CommentChannels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentChannel = commentChannelService.GetDetailsById(id);
            if (commentChannel == null)
            {
                return NotFound();
            }

            return View(commentChannel);
        }

        // GET: CommentChannels/Create
        public IActionResult Create()
        {
            ViewData["ProfileId"] = new SelectList(commentChannelService.GetAllProfiles(), "ProfileId", "ProfileId");
            return View();
        }

        // POST: CommentChannels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentChannelId,ProfileId,Comment,NrLikes,NrDislikes")] CommentChannel commentChannel)
        {
            if (ModelState.IsValid)
            {
                commentChannelService.Create(commentChannel);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfileId"] = new SelectList(commentChannelService.GetAllProfiles(), "ProfileId", "ProfileId", commentChannel.ProfileId);
            return View(commentChannel);
        }

        // GET: CommentChannels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentChannel = commentChannelService.GetDetailsById(id);

            if (commentChannel == null)
            {
                return NotFound();
            }
            ViewData["ProfileId"] = new SelectList(commentChannelService.GetAllProfiles(), "ProfileId", "ProfileId", commentChannel.ProfileId);
            return View(commentChannel);
        }

        // POST: CommentChannels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentChannelId,ProfileId,Comment,NrLikes,NrDislikes")] CommentChannel commentChannel)
        {
            if (id != commentChannel.CommentChannelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    commentChannelService.UpdateCommentChannel(commentChannel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!commentChannelService.CommentChannelExists(commentChannel.CommentChannelId))
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
            ViewData["ProfileId"] = new SelectList(commentChannelService.GetAllProfiles(), "ProfileId", "ProfileId", commentChannel.ProfileId);
            return View(commentChannel);
        }

        // GET: CommentChannels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentChannel = commentChannelService.GetDetailsById(id);

            if (commentChannel == null)
            {
                return NotFound();
            }

            return View(commentChannel);
        }

        // POST: CommentChannels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            commentChannelService.DeleteCommentChannel(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
