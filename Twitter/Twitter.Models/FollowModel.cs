using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class FollowModel
    {
        public int IdFollow { get; set; }
        public int IdSubscriber { get; set; }
        public int IdFollowedUser { get; set; }
    }
}
