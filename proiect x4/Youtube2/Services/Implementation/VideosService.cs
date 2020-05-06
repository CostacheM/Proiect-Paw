using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube2.Model;
using Youtube2.Services.Interfaces;

namespace Youtube2.Services.Implementation
{
    public class VideosService
    {
        private IRepositoryWrapper _repo;

        public VideosService(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }
        public List<Videos> GetAllVideos()
        {
            return this._repo.Video.FindAll();
        }
        public Videos GetDetailsById(int? id)
        {
            return _repo.Video.FindByCondition(m => m.VideosId == id);
        }

        //lista FK-urilor
        public List<Profile> GetAllProfiles()
        {
            return _repo.Profile.FindAll();
        }

        public void Create(Videos videos)
        {
            _repo.Video.Create(videos);
            _repo.Save();
        }
        public void UpdateVideos(Videos videos)
        {
            _repo.Video.Update(videos);
            _repo.Save();
        }
        public bool VideosExists(int id)
        {
            bool found = _repo.Video.VideosExist(id);
            return found;
        }
        public void DeleteVideos(int id)
        {
            var videos = _repo.Video.FindByCondition(m => m.VideosId == id);
            _repo.Video.Delete(videos);

            _repo.Save();
        }
    }
}
