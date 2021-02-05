using Microsoft.AspNet.Identity;
using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialMedia.WebAPI.Controllers
{
    public class PostController : ApiController
    {
        public IHttpActionResult Get()
        {
            var service = CreatePostService();
            return Ok(service.GetPosts());
        }
        public IHttpActionResult Get(int id)
        {
            var service = CreatePostService();
            return Ok(service.GetPostById(id));
        }
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreatePostService();
            if (!service.CreatePost(post))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Put(PostEdit post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreatePostService();
            if (!service.UpdatePost(post))
            {
                return InternalServerError();
            }
            return Ok();


        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostService();
            if(!service.DeletePost(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }


    }
}
