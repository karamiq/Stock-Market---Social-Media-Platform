using api.dtos.comment;
using api.Models;

namespace api.Mappers
{

    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                title = comment.Title,
                content = comment.Content,
                createdAt = comment.CreatedAt,
                StockId = comment.StockId
            };
        }

        public static Comment ToCommentFromCreateModel(this CreateCommentDto commentDto, int stockId)
        {
            return new Comment
            {
                Title = commentDto.title,
                Content = commentDto.content,
                CreatedAt = DateTime.UtcNow,
                StockId = stockId
            };
        }

        public static Comment ToCommentFromCreateModel(this UpdateCommentDto updateDto, int stockId)
        {
            return new Comment
            {
                Title = updateDto.title,
                Content = updateDto.content
            };
        }
       
    }
}