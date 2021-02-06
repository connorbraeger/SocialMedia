using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class LikeService
    {
        private readonly Guid _userId;
        public LikeService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLike(LikeCreate model)
        {
            var entity = new Like()
            {
                ApplicationUserId = _userId.ToString(),
                PostId = model.PostId,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }
        public LikeDetail GetLikeByInt(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Likes.Single(e => e.LikeId == id);
                return new LikeDetail
                {
                    LikeId = entity.LikeId,
                    ChildContentUsername = entity.ApplicationUser.UserName,
                    CreatedUtc = entity.CreatedUtc,
                    ParentContentTitle = entity.Post.Title,
                    ParentContentUsername = entity.Post.ApplicationUser.UserName,
                };
            }
        }
        public IEnumerable<LikeDetail> GetLikesByParentContent(int parentContentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Likes.Where(e => e.PostId == parentContentId).Select(e => new LikeDetail
                {
                    LikeId = e.LikeId,
                    ParentContentUsername = e.Post.ApplicationUser.UserName,
                    ChildContentUsername = e.ApplicationUser.UserName,
                    CreatedUtc = e.CreatedUtc,
                    ParentContentTitle = e.Post.Title
                });
                return query.ToArray();

            }
        }
        public IEnumerable<LikeDetail> GetLikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Likes.Select(
                    e => new LikeDetail
                    {
                        LikeId = e.LikeId,
                        ParentContentUsername = e.Post.ApplicationUser.UserName,
                        ChildContentUsername = e.ApplicationUser.UserName,
                        CreatedUtc = e.CreatedUtc,
                        ParentContentTitle = e.Post.Title
                    });
                return query.ToArray();

            }
        }
        public IEnumerable<LikeDetail> GetLikesByUserId(string id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Likes.Where(e => e.ApplicationUserId == id).Select(e => new LikeDetail
                {
                    LikeId = e.LikeId,
                    ChildContentUsername = e.ApplicationUser.UserName,
                    ParentContentTitle = e.Post.Title,
                    ParentContentUsername = e.Post.ApplicationUser.UserName,
                    CreatedUtc = e.CreatedUtc
                });
                return query.ToArray();
            }
        }
        public bool DeleteLike(int id) 
        { 
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Likes.Single(e => e.LikeId == id);
                ctx.Likes.Remove(entity);
                return ctx.SaveChanges() >= 1;
            }
        }
    }
}
