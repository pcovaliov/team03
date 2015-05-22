using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class FollowModel
    {
        public int idFollow { get; set; }
        public int idSubscriber { get; set; }
        public int idFollowedUser { get; set; }
    }
}
