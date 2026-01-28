using api.Models;

namespace api.interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllCommentsAsync();
        Task<Comment?> GetCommentByIdAsync(int id);
        Task<Comment> CreateCommentAsync(Comment comment);
        Task<Comment?> UpdateCommentAsync(int id, Comment updatedComment);
        Task<Comment?> DeleteCommentAsync(int id);
    }
}
