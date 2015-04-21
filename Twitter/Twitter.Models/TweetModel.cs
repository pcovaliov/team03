using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public  class TweetModel
    {
        public int IdTweet { get; set; }
        public string Descripton { get; set; }
        public int IdUser { get; set; }
        public byte[] CreatedOn { get; set; }
    }
}
