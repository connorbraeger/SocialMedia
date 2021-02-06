using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class LikeListItem
    {
        //public string ParentContentTitle { get; set; }
        public string ChildContentUsername { get; set; }
        public DateTimeOffset   CreatedUtc { get; set; }

    }
}
