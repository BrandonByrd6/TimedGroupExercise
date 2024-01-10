using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TGE.Models.Post;
using TGE.Services.Post;

namespace TGE.WebAPI.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostCreate request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _postService.CreatePostAsync(request);
            if (!response)
                return BadRequest("Could Not Create Post");

            return Ok("Post Created");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{authorId:int}")]
        public async Task<IActionResult> GetPostsByAuthorId([FromRoute] int authorId)
        {
            var posts = await _postService.GetPostByAuthorIdAsync(authorId);
            return Ok(posts);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdatePost([FromBody] PostUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _postService.UpdatePostAsync(request) ? Ok("Post Update Successfully") : BadRequest("Post Could not be updated");

        }

        [HttpDelete("{postId:int}")]
        public async Task<IActionResult> deletePost([FromRoute] int postId)
        {
            return await _postService.DeletePostAsync(postId) ? Ok($"Post {postId} was deleted successfully") : BadRequest($"Post {postId} was unable to be deleted!");
        }
    }

}