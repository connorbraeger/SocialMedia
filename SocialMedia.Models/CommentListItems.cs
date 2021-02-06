using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    class CommentListItems
    {
        public class NoteListItem
        {
            public int NoteId { get; set; }
            public string Title { get; set; }

            [Display(Name = "Created")]
            public DateTimeOffset CreatedUtc { get; set; }
        }
    }
}
