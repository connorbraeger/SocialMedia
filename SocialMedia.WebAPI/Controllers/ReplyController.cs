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
    public class ReplyController : ApiController
    {
        public IHttpActionResult Get()
        {
            var service = CreateReplyService();
            return Ok(service.GetReplies());
        }
        public IHttpActionResult Get(int id)
        {
            var service = CreateReplyService();
            return Ok(service.GetReplyById(id));
        }
        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateReplyService();
            if (!service.CreateReply(reply))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Put(ReplyEdit reply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateReplyService();
            if (!service.UpdateReply(reply))
            {
                return InternalServerError();
            }
            return Ok();


        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateReplyService();
            if (!service.DeleteReply(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }
    }
}
