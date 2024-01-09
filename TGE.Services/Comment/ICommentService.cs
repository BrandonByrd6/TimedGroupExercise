using System.Runtime.InteropServices;
using TGE.Models.Comment;

namespace TGE.Services.Comment;

public interface ICommentService
{
        Task<bool> CreateCommentAsync(CommentCreate postCreate);

        Task<IEnumerable<CommentDetail>> GetCommentsByPostIdAsync(int id);
        
        Task<IEnumerable<CommentDetail>> GetCommentsByAuthorIdAsync(int id);

        Task<bool> UpdateCommentAsync(CommentUpdate request);

        Task<bool> DeleteCommentAsync(int id);



}
