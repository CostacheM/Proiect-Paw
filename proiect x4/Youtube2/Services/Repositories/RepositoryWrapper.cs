using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube2.Data;
using Youtube2.Services.Interfaces;

namespace Youtube2.Services.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ProfileDBContext _repoContext;

        private IProfileRepository _profile;
        private ISubbsRepository _subbs;
        private IVideosRepository _videos;
        private ICommentChannelRepository _commentChannel;
        private ICommentVideoRepository _commentVideo;


        public IProfileRepository Profile
        {
            get
            {
                if (_profile == null)
                {
                    _profile = new ProfileRepository(_repoContext);
                }

                return _profile;
            }
        }

        public IVideosRepository Video
        {
            get
            {
                if (_videos == null)
                {
                    _videos = new VideosRepository(_repoContext);
                }

                return _videos;
            }
        }

        public ISubbsRepository Subscription
        {
            get
            {
                if (_subbs == null)
                {
                    _subbs = new SubbsRepository(_repoContext);
                }

                return _subbs;
            }
        }

        public ICommentChannelRepository CommentChannel
        {
            get
            {
                if (_commentChannel == null)
                {
                    _commentChannel = new CommentChannelRepository(_repoContext);
                }

                return _commentChannel;
            }
        }

        public ICommentVideoRepository CommentVideo
        {
            get
            {
                if (_commentVideo == null)
                {
                    _commentVideo = new CommentVideoRepository(_repoContext);
                }

                return _commentVideo;
            }
        }

        public RepositoryWrapper(ProfileDBContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
