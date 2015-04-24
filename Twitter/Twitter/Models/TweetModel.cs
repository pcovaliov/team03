using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter.Models
{
    public class TweetModel
    {
        public string Descripton { get; set; }
        public int IdUser { get; set; }
        public byte[] CreatedOn { get; set; }
    }
}