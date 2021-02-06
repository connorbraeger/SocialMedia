using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                ApplicationUserId = _userId.ToString(),
                Title = model.Title,
                Text = model.Text,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() > 0;
            }


        }
        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Replies.Select(
                    e =>
                        new ReplyListItem
                        {
                            ReplyId = e.ReplyId,
                            Title = e.Title,
                            CreatedUtc = e.CreatedUtc,
                        }
                    ) ;
                return query.ToArray();
            }
        }
        public ReplyDetail GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Replies.Single(e => e.ReplyId == id);
                return new ReplyDetail
                {
                    ReplyId = entity.ReplyId,
                    Title = entity.Title,
                    Text = entity.Text,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc,
                };
            }
        }
        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Replies.Single(e => Guid.Parse(e.ApplicationUserId) == _userId && e.ReplyId == model.ReplyId);
                entity.Text = model.Text;
                entity.Title = model.Title;
                entity.ModifiedUtc = DateTimeOffset.Now;
                return ctx.SaveChanges() >= 1;

            }
        }
        public bool DeleteReply(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Replies.Single(e => Guid.Parse(e.ApplicationUserId) == _userId && e.ReplyId == id);
                ctx.Replies.Remove(entity);
                return ctx.SaveChanges() >= 1;
            }
        }
    }
}
