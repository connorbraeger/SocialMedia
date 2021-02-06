using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
       
        public virtual Post Post { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }



    }
}
