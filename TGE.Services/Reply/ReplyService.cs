using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TGE.Data;
using TGE.Data.Entities;
using TGE.Models.Reply;

namespace TGE.Services.Reply
{
    public class ReplyService : IReplyService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly int _userId;

        public ReplyService(UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager,
                            ApplicationDbContext dbContext)
        {
            var  currentUser = signInManager.Context.User;
            var userIdClaim = userManager.GetUserId(currentUser);
            var hasValidId = int.TryParse(userIdClaim, out _userId);
            if (!hasValidId)
            {
                throw new Exception("Attempted to build ReplyService w/o ID claim");
            }

            _dbContext = dbContext;
        }

        public async Task<ReplyListItem?> CreateReplyAsync(ReplyCreate request)
        {
            // var replyEntity = await _dbContext.Comments.FindAsync(ParentId);
                //! ask Terry ^     referencing DeleteNote service method EN API 21.01

            ReplyEntity entity = new()
            {
                ParentId = request.ParentId,
                Text = request.Text
            };
            _dbContext.Replies.Add(entity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            if (numberOfChanges != 1)
            {
                return null;
            }

            ReplyListItem reply = new()
            {
                ParentId = entity.ParentId,
                Text = entity.Text
            };
            return reply;
        }

        public async Task<ReplyDetail?> GetRepliesByCommentIdAsync(int ParentId)
        {
            ReplyEntity? entity = await _dbContext.Replies.FirstOrDefaultAsync(
                e => e.ParentId == ParentId);

            return entity is null ? null : new ReplyDetail
            {
                ParentId = entity.ParentId,
                Text = entity.Text
            };
        }

        public async Task<bool> DeleteReplyAsync(int Id)
        {
            var replyEntity = await _dbContext.Replies.FindAsync(Id);

            if (replyEntity?.AuthorId != _userId)   
            {
                return false;
            }

            _dbContext.Replies.Remove(replyEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}