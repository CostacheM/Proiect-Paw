using System;
using System.Collections.Generic;

namespace Youtube2.Model
{
    public class Videos
    {
        public int VideosId { get; set; }
        public int ProfileId { get; set; } 
        public string Description { private get; set; }
        public int NrLikes { get; set; }
        public int NrDislikes { get; set; }
        public int NrComments { get; set; }
        public string Video { get; set; }
        public string Type { get; set; }

        public Profile Profile { get; set; }

        public ICollection<CommentVideo> Comm { get; set; }

    }
}
