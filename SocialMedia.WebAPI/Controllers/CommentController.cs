using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMedia.WebAPI.Controllers
{
    public class CommentController
    {
        public class CommentController : ApiController
        {
            public IHttpActionResult Get()
            {
                NoteService noteService = CreateNoteService();
                var notes = noteService.GetNotes();
                return Ok(notes);
            }
            public IHttpActionResult Post(NoteCreate note)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateNoteService();

                if (!service.CreateNote(note))
                    return InternalServerError();

                return Ok();
            }
            private NoteService CreateNoteService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var noteService = new NoteService(userId);
                return noteService;
            }
        }
    }
}