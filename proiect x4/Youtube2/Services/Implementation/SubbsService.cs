using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube2.Model;
using Youtube2.Services.Interfaces;

namespace Youtube2.Services.Implementation
{
    public class SubbsService
    {
        private IRepositoryWrapper _repo;

        public SubbsService(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }
        public List<Subscription> GetAllSubscriptions()
        {
            return this._repo.Subscription.FindAll();
        }
        public Subscription GetDetailsById(int? id)
        {
            return _repo.Subscription.FindByCondition(m => m.SubscriptionId == id);
        }

        //lista FK-urilor
        /*public List<Subscription> GetAllSubbs()
        {
            return _repo.Subscription.FindAll();
        }*/

        public void Create(Subscription subscription)
        {
            _repo.Subscription.Create(subscription);
            _repo.Save();
        }
        public void UpdateSubscription(Subscription subscription)
        {
            _repo.Subscription.Update(subscription);
            _repo.Save();
        }
        public bool SubscriptionExists(int id)
        {
            bool found = _repo.Subscription.SubscriptionExist(id);
            return found;
        }
        public void DeleteSubscription(int id)
        {
            var subscription = _repo.Subscription.FindByCondition(m => m.SubscriptionId == id);
            _repo.Subscription.Delete(subscription);

            _repo.Save();
        }
    }
}
