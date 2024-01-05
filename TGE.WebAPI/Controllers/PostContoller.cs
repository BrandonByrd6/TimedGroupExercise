using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TGE.Models.Post;
using TGE.Services.Post;

namespace TGE.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PostContoller : ControllerBase
{
    private readonly IPostService _postService;

    public PostContoller(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] PostCreate request) {
        if(!ModelState.IsValid) return BadRequest(ModelState);

        var response = await _postService.CreatePostAsync(request);
        if(!response)
            return BadRequest("Could Not Create Post");
        
        return Ok("Post Created");
    }


    [HttpGet]
    public async Task<IActionResult> GetAllPosts() {
        var posts = await _postService.GetAllPostsAsync();
        return Ok(posts);
    }

    [HttpGet("{authorId:int}")]
    public async Task<IActionResult> GetPostsByAuthorId([FromRoute] int authorId) {
        var posts = await _postService.GetPostByAuthorIdAsync(authorId);
        return Ok(posts);
    }

    [HttpPut("{postId:int}")]
    public async Task<IActionResult> UpdatePost([FromRoute] int postId) {
        var posts = await _postService.UpdatePostAsync(postId);
        return Ok(posts);
    }

    [HttpDelete("{postId:int}")]
    public async Task<IActionResult> deletePost([FromRoute] int postId) {
        var posts = await _postService.DeletePostAsync(postId);
        return Ok(posts);
    }
}

