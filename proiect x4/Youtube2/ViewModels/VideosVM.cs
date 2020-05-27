using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube2.Model;

namespace Youtube2.ViewModels
{
    public class VideosVM
    {
        public int Index { get; set; }
        public List<Videos> videos { get; set; }
    }
}
