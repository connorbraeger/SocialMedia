using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    class Comments
    {
        [Key]
        public int ComId { get; set; }
 
        [Required]
        [MaxLength(520)]
        public string Content { get; set; }
        
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
       
    }
}
