using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        //[ForeignKey(nameof(Comment))]
        //public int CommentId { get; set; }

        //public virtual Comment Comment { get; set; }

        public string ApplicationUserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Text { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
