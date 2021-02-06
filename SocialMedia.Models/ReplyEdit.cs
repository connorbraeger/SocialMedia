using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class ReplyEdit
    {
        [Required]
        public int ReplyId { get; set; }
        public string Title { get; set; }

        public string Text { get; set; }
    }
}
