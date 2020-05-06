using System;
using System.Collections.Generic;
using System.Text;

namespace Youtube2.Model
{
    public class CommentVideo
    {
        public int CommentVideoId { get; set; }
        public int VideosId { get; set; }
        public string Comment { get; set; }
        public int NrLikes { get; set; }
        public int NrDislikes { get; set; }

        public Videos Videos { get; set; }
    }
}
