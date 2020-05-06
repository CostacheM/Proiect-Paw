using Youtube2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Youtube2.Services.Interfaces
{
    public interface IVideosRepository : IRepositoryBase<Videos>
    {
        public bool VideosExist(int id);
    }
}
