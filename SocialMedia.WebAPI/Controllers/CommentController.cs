using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SocialMedia.WebAPI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        public IHttpActionResult Get()
        {
            var service = CreateCommentService();
            return Ok(service.GetPosts());
        }
        public IHttpActionResult Get(int id)
        {
            var service = CreateCommentService();
            return Ok(service.GetCommnetById(id));
        }
        public IHttpActionResult Post(CommentCreate post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateCommentService();
            if (!service.CreateComment(post))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Put(CommentEdit post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateCommentService();
            if (!service.UpdatePost(post))
            {
                return InternalServerError();
            }
            return Ok();

        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCommentService();
            if (!service.DeletePost(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
        private CommentService CreateCommnetService()
        {
            var comId = Guid.Parse(User.Identity.GetComId());
            var commmentService = new CommentService(userId);
            return commmentService;
        }


    }