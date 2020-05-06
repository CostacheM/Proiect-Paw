using Youtube2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Youtube2.Services.Interfaces
{
    public interface ICommentVideoRepository : IRepositoryBase<CommentVideo>
    {
        public bool CommentVideoExist(int id);
    }
}
