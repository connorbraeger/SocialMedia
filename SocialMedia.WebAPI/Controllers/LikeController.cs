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
    [Authorize]
    public class LikeController : ApiController
    {
       
        [HttpPost]
        public IHttpActionResult Post(LikeCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateLikeService();
            if (!service.CreateLike(model))
                return InternalServerError();
            return Ok();
        } 
        [HttpGet]
        public IHttpActionResult Get()//Get Likes
        {
            var service = CreateLikeService();
            return Ok(service.GetLikes());
        }
        [Route("likes/{id}/Posts")]
        [HttpGet]
        public IHttpActionResult GetLikesbyPost(int id)//GetLikesByParentContent
        {
            var service = CreateLikeService();
            return Ok(service.GetLikesByParentContent(id));
        }
       
        public IHttpActionResult Get(int id)//Get Like By Id
        {
            var service = CreateLikeService();
            return Ok(service.GetLikeByInt(id));
        }
        [Route("likes/{id}/Users")]
        public IHttpActionResult Get(string id)
        {
            var service = CreateLikeService();
            return Ok(service.GetLikesByUserId(id));
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateLikeService();
            if (!service.DeleteLike(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var LikeService = new LikeService(userId);
            return LikeService;
        }
    }
}
