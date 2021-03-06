﻿using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                ApplicationUserId = _userId.ToString(),
                Title = model.Title,
                Text = model.Text,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() > 0;
            }


        }
        public IEnumerable<PostListItem> GetPosts()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Posts.Select(
                    e =>
                        new PostListItem
                        {
                            PostId = e.PostId,
                            Title = e.Title,
                            CreatedUtc = e.CreatedUtc,
                            UserName = e.ApplicationUser.UserName
                        }
                    );
                return query.ToArray();
            }
        }
        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(e => e.PostId == id);
                return new PostDetail
                {
                    PostId = entity.PostId,
                    Title = entity.Title,
                    Text = entity.Text,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc,
                    UserName = entity.ApplicationUser.UserName
                };
            }
        }
        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(e => Guid.Parse(e.ApplicationUserId) == _userId && e.PostId == model.PostId);
                entity.Text = model.Text;
                entity.Title = model.Title;
                entity.ModifiedUtc = DateTimeOffset.Now;
                return ctx.SaveChanges() >= 1;

            }
        }
        public bool DeletePost (int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(e => Guid.Parse(e.ApplicationUserId) == _userId && e.PostId == id);
                ctx.Posts.Remove(entity);
                return ctx.SaveChanges() >= 1;
            }            
        }

    }
}
