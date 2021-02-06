using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    class CommentEdit
    {
        [Required]
        public int ComId { get; set; }
        public string Content { get; set; }
    }
}
