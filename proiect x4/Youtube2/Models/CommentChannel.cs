using System;
using System.Collections.Generic;
using System.Text;

namespace Youtube2.Model
{
    public class CommentChannel
    {
       
        public int CommentChannelId { get; set; }

        public int ProfileId { get; set; }
        public string Comment { get; set; }
        public int NrLikes { get; set; }
        public int NrDislikes { get; set; }

        public Profile Profile { get; set; }
    }
}
