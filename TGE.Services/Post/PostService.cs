using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TGE.Data;
using TGE.Data.Entities;
using TGE.Models.Post;

namespace TGE.Services.Post;

public class PostService : IPostService
{

    private readonly ApplicationDbContext _dbContext;
    private readonly int _userId;

    public PostService(UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager,
        ApplicationDbContext dbContext)
    {
        var currentUser = signInManager.Context.User;
        var userIdClaim = userManager.GetUserId(currentUser);
        var hasValidId = int.TryParse(userIdClaim, out _userId);
        
        if(hasValidId == false) {
            throw new Exception("Attempted to build PostService with out Id  Claim");
        }

        _dbContext = dbContext;
    }

    public async Task<bool> CreatePostAsync(PostCreate postCreate)
    {
        PostEntity entity = new(){
            Title = postCreate.Title,
            AuthorId = _userId,
            Text = postCreate.Text
        };

        _dbContext.Posts.Add(entity);
        var changes = await _dbContext.SaveChangesAsync();
        if(changes != 1) return false;

        return true;
    }

    public Task<bool> DeletePostAsync(int id)
    {
         throw new NotImplementedException();
    }

    public async Task<IEnumerable<PostDetail>> GetAllPostsAsync()
    {
        List<PostDetail> posts = await _dbContext.Posts.Select(entity => new PostDetail{
            Id = entity.Id,
            Title = entity.Title,
            Text = entity.Text,
        }).ToListAsync();

        return posts;
    }

    public async Task<IEnumerable<PostDetail>> GetPostByAuthorIdAsync(int id)
    {
         List<PostDetail> posts = await _dbContext.Posts
         .Where(entity => entity.AuthorId == id)
         .Select(entity => new PostDetail{
            Id = entity.Id,
            Title = entity.Title,
            Text = entity.Text,
        }).ToListAsync();

        return posts;
    }
}
