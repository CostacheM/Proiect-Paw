using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Youtube2.Data;
using Youtube2.Model;
using Youtube2.Services.Interfaces;

namespace Youtube2.Services.Repositories
{
    public class CommentVideoRepository : RepositoryBase<CommentVideo>, ICommentVideoRepository
    {
        public CommentVideoRepository(ProfileDBContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool CommentVideoExist(int id)
        {
            var found = RepositoryContext.CommVideo.Any(e => e.CommentVideoId == id);
            return found;
        }

        public CommentVideo FindByCondition(Expression<Func<CommentVideo, bool>> expression)
        {
            return this.RepositoryContext.CommVideo
                .Include(c => c.Videos)
                .Where(expression)
                .FirstOrDefault();
        }

        public List<CommentVideo> FindAll()
        {
            return this.RepositoryContext.CommVideo
                .Include(c => c.Videos)
                .ToList();

        }
    }
}
