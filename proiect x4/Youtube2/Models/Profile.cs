﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Youtube2.Model
{
    public class Profile
    {
        public string ProfileId { get; set; }     
        public string Nume { get; set; }
        public string MailAdress { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public int NrLikesT { get; set; }
        public int NrDislikesT { get; set; }
        public int NrSubscribers { get; set; }
        public int SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }
        public ICollection<Videos> Video { get; set; }
        public ICollection<CommentChannel> CommChannels { get; set; }
    }
}
