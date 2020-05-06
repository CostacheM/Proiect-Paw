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
    public class ProfileRepository : RepositoryBase<Profile>, IProfileRepository
    {
        public ProfileRepository(ProfileDBContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool ProfileExists(int id)
        {
            var found = RepositoryContext.Profile.Any(e => e.ProfileId == id);
            return found;
        }

        public Profile FindByCondition(Expression<Func<Profile, bool>> expression)
        {
            return this.RepositoryContext.Profile
                .Include(c => c.Subscription)
                .Where(expression)
                .FirstOrDefault();
        }

        public List<Profile> FindAll()
        {
            return this.RepositoryContext.Profile
                .Include(c => c.Subscription)
                .ToList();

        }
    }
}
