using System;
using System.Collections.Generic;
using System.Text;

namespace Youtube2.Model
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public bool Notification { get; set; }

        public ICollection<Profile> Subs { get; set; }

    }
}
