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
        public string ChildContentUsername { get; set; }//Username of user that liked comment
        public DateTimeOffset CreatedUtc { get; set; }
        public string ParentContentTitle { get; set; }
        public string ParentContentUsername { get; set; }//Author of liked Post
    }
}
