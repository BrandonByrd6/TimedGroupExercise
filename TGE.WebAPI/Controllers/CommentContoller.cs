using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TGE.Models.Comment;
using TGE.Services.Comment;

namespace TGE.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CommentCreate request) {
        if(!ModelState.IsValid) return BadRequest(ModelState);

        var response = await _commentService.CreateCommentAsync(request);
        if(!response)
            return BadRequest("Could Not Create Comment");
        
        return Ok("Comment Created");
    }


    [HttpGet("post/{postId:int}")]
    public async Task<IActionResult> GetCommentsByPostId([FromRoute] int postId) {
        var comments = await _commentService.GetCommentsByPostIdAsync(postId);
        return Ok(comments);
    }

    [HttpGet("author/{authorId:int}")]
    public async Task<IActionResult> GetCommentsByAuthorId([FromRoute] int authorId) {
        var comments = await _commentService.GetCommentsByAuthorIdAsync(authorId);
        return Ok(comments);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateComment([FromBody] CommentUpdate request) {
        if(!ModelState.IsValid)
            return BadRequest();
        
        return await _commentService.UpdateCommentAsync(request) ? Ok("Comment Update Successfully") : BadRequest("Comment Could not be updated");
    
    }

    [HttpDelete("{commentId:int}")]
    public async Task<IActionResult> DeleteComment([FromRoute] int commentId) {
        return await _commentService.DeleteCommentAsync(commentId) ? Ok($"Comment {commentId} was deleted successfully") : BadRequest($"Comment {commentId} was unable to be deleted!");
    }
}

