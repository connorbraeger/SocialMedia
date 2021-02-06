using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                Author = _userId,
                Text = model.Content,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comment.Add(entity);
                return ctx.SaveChanges() > 0;
            }

        }
        public IEnumerable<CommentListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Comment.Where(e => e.Author == _userId).Select(
                    e =>
                        new CommentListItem
                        {
                            ComId = e.ComId,
                            Text = e.Content,
                            CreatedUtc = e.CreatedUtc
                        }
                    );
                return query.ToArray();
            }
        }
        public CommentDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comment.Single(e => e.ComId == id && e.Author == _userId);
                return new CommentDetail
                {
                    PostId = entity.PostId,
                    Text = entity.Content,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }
        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comment.Single(e => e.Author == _userId && e.ComId == model.ComId);
                entity.Text = model.Content;
                entity.ModifiedUtc = DateTimeOffset.Now;
                return ctx.SaveChanges() >= 1;

            }
        }
        public bool DeleteComment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comment.Single(e => e.Author == _userId && e.ComId == id);
                ctx.Comment.Remove(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

    }
}
