using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Twitter.Model
{
    public class TweetModel
    {
        [Required(ErrorMessage = "Please enter tweet", AllowEmptyStrings = false)]
        [StringLength(140, ErrorMessage = "Tweet can't exceed 140 characters.")]
        public string Descripton { get; set; }
        public int IdUser { get; set; }
        public string CreatedOn { get; set; }
    }
}
