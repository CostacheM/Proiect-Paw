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
    public class VideosRepository : RepositoryBase<Videos>, IVideosRepository
    {
        public VideosRepository(ProfileDBContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool VideosExist(int id)
        {
            var found = RepositoryContext.Video.Any(e => e.VideosId == id);
            return found;
        }

        public Videos FindByCondition(Expression<Func<Videos, bool>> expression)
        {
            return this.RepositoryContext.Video
                .Include(c => c.Profile)
                .Where(expression)
                .FirstOrDefault();
        }

        public List<Videos> FindAll()
        {
            return this.RepositoryContext.Video
                .Include(c => c.Profile)
                .ToList();

        }
    }
}
