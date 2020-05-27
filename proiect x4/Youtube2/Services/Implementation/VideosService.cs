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
        private List<string> links = new List<string>(20);
        private List<Videos> videos = new List<Videos>(200);


        public VideosService(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }
        public List<Videos> GetAllVideos()
        {
            return this._repo.Video.FindAll();
        }

        public List<string> GetAllLinksById(string id)
        {
            foreach (var item in this._repo.Video.FindAll())
            {
                if (item.ProfileId == id)
                {
                    links.Add(item.Video);
                }

            }
            return links;
        }

        public List<Videos> GetVideosByUserId(string id)
        {
            foreach (var item in this._repo.Video.FindAll())
            {
                if (item.ProfileId == id)
                {
                    videos.Add(item);
                }

            }
            return videos;
        }

        public List<Videos> GetAllVideosOrdered()
        {
            var videos = this._repo.Video.FindAll();
            List < Videos > query = videos.OrderByDescending(vid => vid.NrLikes).ToList();

            return query;
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

        public void Create(Videos videos, string profilId)
        {
            videos.ProfileId = profilId;
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
