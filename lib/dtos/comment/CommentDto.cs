namespace api.dtos.comment
{
    public class CommentDto
    {
         public int Id { get; set; }

        public string title { get; set; } = string.Empty;

        public string content { get; set; } = string.Empty;
         public DateTime createdAt { get; set; } = DateTime.Now;

         public int StockId { get; set; }
    }
}