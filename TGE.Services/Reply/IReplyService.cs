using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGE.Models.Reply;

namespace TGE.Services.Reply
{
    public interface IReplyService
    {
        Task<ReplyListItem?> CreateReplyAsync(ReplyCreate request);
        Task<ReplyDetail?> GetRepliesByCommentIdAsync(int ParentId);
        Task<bool> DeleteReplyAsync(int Id);
    }
}