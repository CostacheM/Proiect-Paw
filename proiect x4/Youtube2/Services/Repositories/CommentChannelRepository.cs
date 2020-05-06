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
    public class CommentChannelRepository : RepositoryBase<CommentChannel>, ICommentChannelRepository
    {
        public CommentChannelRepository(ProfileDBContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool CommentChannelExist(int id)
        {
            var found = RepositoryContext.CommCh.Any(e => e.CommentChannelId == id);
            return found;
        }

        public CommentChannel FindByCondition(Expression<Func<CommentChannel, bool>> expression)
        {
            return this.RepositoryContext.CommCh
                .Include(c => c.Profile)
                .Where(expression)
                .FirstOrDefault();
        }

        public List<CommentChannel> FindAll()
        {
            return this.RepositoryContext.CommCh
                .Include(c => c.Profile)
                .ToList();

        }
    }
}
