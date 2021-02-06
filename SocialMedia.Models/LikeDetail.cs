using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class LikeDetail
    {
        public int LikeId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public string PostTitle { get; set; }
        public string Author { get; set; }//Author of liked Post
    }
}
