using Youtube2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Youtube2.Services.Interfaces
{
    public interface ISubbsRepository : IRepositoryBase<Subscription>
    {
        public bool SubscriptionExist(int id);
    }
}
