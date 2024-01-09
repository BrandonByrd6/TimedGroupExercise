using System.Runtime.InteropServices;
using TGE.Models.Post;

namespace TGE.Services.Post;

public interface IPostService
{
        Task<bool> CreatePostAsync(PostCreate postCreate);

        Task<IEnumerable<PostDetail>> GetAllPostsAsync();
        
        Task<IEnumerable<PostDetail>> GetPostByAuthorIdAsync(int id);

        Task<bool> UpdatePostAsync(PostUpdate request);

        Task<bool> DeletePostAsync(int id);



}
