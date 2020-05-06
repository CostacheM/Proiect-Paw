using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Youtube2.Services.Interfaces
{
    public interface IRepositoryWrapper
    {
        public IProfileRepository Profile { get; }
        public IVideosRepository Video { get; }
        public ISubbsRepository Subscription { get; }
        public ICommentChannelRepository CommentChannel { get; }
        public ICommentVideoRepository CommentVideo { get; }

        public void Save();
    }
}
