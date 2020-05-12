
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube2.Model;

namespace Youtube2.Services.Interfaces
{
    public interface IProfileRepository : IRepositoryBase<Profile>
    {
        public bool ProfileExists(string id);
    }
}
