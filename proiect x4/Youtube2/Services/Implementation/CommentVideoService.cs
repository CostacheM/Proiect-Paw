using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube2.Model;
using Youtube2.Services.Interfaces;

namespace Youtube2.Services.Implementation
{
    public class CommentVideoService
    {
        private IRepositoryWrapper _repo;

        public CommentVideoService(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }
        public List<CommentVideo> GetAllCommentVideo()
        {
            return this._repo.CommentVideo.FindAll();
        }
        public CommentVideo GetDetailsById(int? id)
        {
            return _repo.CommentVideo.FindByCondition(m => m.CommentVideoId == id);
        }

        //lista FK-urilor
        public List<Videos> GetAllVideos()
        {
            return _repo.Video.FindAll();
        }

        public void Create(CommentVideo commentVideo)
        {
            _repo.CommentVideo.Create(commentVideo);
            _repo.Save();
        }
        public void UpdateCommentVideo(CommentVideo commentVideo)
        {
            _repo.CommentVideo.Update(commentVideo);
            _repo.Save();
        }
        public bool CommentVideoExists(int id)
        {
            bool found = _repo.CommentVideo.CommentVideoExist(id);
            return found;
        }
        public void DeleteCommentVideo(int id)
        {
            var commentVideo = _repo.CommentVideo.FindByCondition(m => m.CommentVideoId == id);
            _repo.CommentVideo.Delete(commentVideo);

            _repo.Save();
        }
    }
}
