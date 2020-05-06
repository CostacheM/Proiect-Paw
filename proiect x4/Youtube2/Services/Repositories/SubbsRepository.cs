using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube2.Data;
using Youtube2.Model;
using Youtube2.Services.Interfaces;

namespace Youtube2.Services.Repositories
{
    public class SubbsRepository: RepositoryBase<Subscription>, ISubbsRepository
    {
        public SubbsRepository(ProfileDBContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool SubscriptionExist(int id)
        {
            var found = RepositoryContext.Subs.Any(e => e.SubscriptionId == id);
            return found;
        }
    }
}
