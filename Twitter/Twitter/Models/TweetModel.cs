using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class TweetModel
    {
        [Required(ErrorMessage = "Please enter the message", AllowEmptyStrings = false)]
        [StringLength(140, ErrorMessage = "The message value cannot exceed 140 characters")]
        public string Descripton { get; set; }
        public int IdUser { get; set; }
        public byte[] CreatedOn { get; set; }
    }
}