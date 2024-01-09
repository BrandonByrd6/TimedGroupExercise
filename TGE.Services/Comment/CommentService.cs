using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TGE.Data;
using TGE.Data.Entities;
using TGE.Models.Comment;

namespace TGE.Services.Comment;

public class CommentService : ICommentService
{

    private readonly ApplicationDbContext _dbContext;
    private readonly int _userId;

    public CommentService(UserManager<UserEntity> userManager,
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

    public async Task<bool> CreateCommentAsync(CommentCreate commentCreate)
    {
        CommentEntity entity = new(){
            PostId = commentCreate.PostId,
            AuthorId = _userId,
            Text = commentCreate.Text
        };

        _dbContext.Comments.Add(entity);
        var changes = await _dbContext.SaveChangesAsync();
        if(changes != 1) return false;

        return true;
    }

    public async Task<bool> DeleteCommentAsync(int id)
    {
        var commentEntity = await _dbContext.Comments.FindAsync(id);

          if(commentEntity?.AuthorId != _userId) 
            return false;

        _dbContext.Comments.Remove(commentEntity);
        return await _dbContext.SaveChangesAsync() == 1;
    }

    public async Task<IEnumerable<CommentDetail>> GetCommentsByPostIdAsync(int id)
    {
        List<CommentDetail> comments = await _dbContext.Comments
         .Where(entity => entity.PostId == id)
         .Select(entity => new CommentDetail{
            Id = entity.Id,
            AuthorId = entity.AuthorId,
            Text = entity.Text,
        }).ToListAsync();

        return comments;
    }

    public async Task<IEnumerable<CommentDetail>> GetCommentsByAuthorIdAsync(int id)
    {
         List<CommentDetail> comments = await _dbContext.Comments
         .Where(entity => entity.AuthorId == id)
         .Select(entity => new CommentDetail{
            Id = entity.Id,
            PostId = entity.PostId,
            Text = entity.Text,
        }).ToListAsync();

        return comments;
    }

    public async Task<bool> UpdateCommentAsync(CommentUpdate request)
    {
        CommentEntity? entity = await _dbContext.Comments.FindAsync(request.Id);

        if(entity?.AuthorId != _userId) 
            return false;
        
        entity.Text = request.Text;

        int numOfChanges = await _dbContext.SaveChangesAsync();

        return numOfChanges == 1;
    }
}
