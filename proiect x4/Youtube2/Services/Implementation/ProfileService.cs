using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube2.Model;
using Youtube2.Services.Interfaces;

namespace Youtube2.Services.Implementation
{
    public class ProfileService
    {
        private IRepositoryWrapper _repo;

        public ProfileService(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }
        public List<Profile> GetAllProfiles()
        {
            return this._repo.Profile.FindAll();
        }
        public Profile GetDetailsById(string? id)
        {
            return _repo.Profile.FindByCondition(m => m.ProfileId == id);
        }

        //lista FK-urilor
        public List<Subscription> GetAllSubbs()
        {
            return _repo.Subscription.FindAll();
        }
        
        public void Create(Profile profile)
        {
            _repo.Profile.Create(profile);
            _repo.Save();
        }
        public void UpdateProfile(Profile profile)
        {
            _repo.Profile.Update(profile);
            _repo.Save();
        }
        public bool ProfileExists(string id)
        {
            bool found = _repo.Profile.ProfileExists(id);
            return found;
        }
        public void DeleteProfile(string id)
        {
            var profile = _repo.Profile.FindByCondition(m => m.ProfileId == id);
            _repo.Profile.Delete(profile);

            _repo.Save();
        }
    }
}
