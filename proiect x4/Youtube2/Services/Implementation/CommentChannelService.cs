using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube2.Model;
using Youtube2.Services.Interfaces;

namespace Youtube2.Services.Implementation
{
    public class CommentChannelService
    {
        private IRepositoryWrapper _repo;

        public CommentChannelService(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }
        public List<CommentChannel> GetAllCommentChannel()
        {
            return this._repo.CommentChannel.FindAll();
        }
        public CommentChannel GetDetailsById(int? id)
        {
            return _repo.CommentChannel.FindByCondition(m => m.CommentChannelId == id);
        }

        //lista FK-urilor
        public List<Profile> GetAllProfiles()
        {
            return _repo.Profile.FindAll();
        }

        public void Create(CommentChannel commentChannel)
        {
            _repo.CommentChannel.Create(commentChannel);
            _repo.Save();
        }
        public void UpdateCommentChannel(CommentChannel commentChannel)
        {
            _repo.CommentChannel.Update(commentChannel);
            _repo.Save();
        }
        public bool CommentChannelExists(int id)
        {
            bool found = _repo.CommentChannel.CommentChannelExist(id);
            return found;
        }
        public void DeleteCommentChannel(int id)
        {
            var commentChannel = _repo.CommentChannel.FindByCondition(m => m.CommentChannelId == id);
            _repo.CommentChannel.Delete(commentChannel);

            _repo.Save();
        }
    }
}
