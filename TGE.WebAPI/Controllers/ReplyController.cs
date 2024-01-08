using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TGE.Models.Reply;
using TGE.Models.Responses;
using TGE.Services.Reply;

namespace TGE.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyService _replyService;

        public ReplyController(IReplyService replyService)
        {
            _replyService = replyService;
        }

        //todo: Need to add ability to add to specific comment
            // call GetRepliesByCommentIdAsync method first to select specific comment to reply to ?
            // or FindAsync method (reference Delete method)
        [HttpPost]
        public async Task<IActionResult> CreateReply([FromBody] ReplyCreate reply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _replyService.CreateReplyAsync(reply);
            if (response is not null)
            {
                return Ok(response);
            }
            return BadRequest(new TextResponse("Could not create reply"));
        }

        [HttpGet("{parentId:int}")]
        public async Task<IActionResult> GetReplyByCommentId([FromRoute] int parentId)
        {
            ReplyDetail? detail = await _replyService.GetRepliesByCommentIdAsync(parentId);

            return detail is not null ? Ok(detail) : NotFound();
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> DeleteReplyAsync([FromRoute] int Id)
        {
            return await _replyService.DeleteReplyAsync(Id)
                ? Ok($"reply {Id} was deleted successfully") : BadRequest($"Note {Id} could not be deleted");
        }
    }
}
