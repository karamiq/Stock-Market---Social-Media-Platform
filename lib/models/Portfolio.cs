using System.ComponentModel.DataAnnotations.Schema;
using models;

namespace api.Models


{
  [Table("Portfolios")]
  public class Portfolio
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public int StockId { get; set; }
    public Stock Stock { get; set; }

    public DateTime CreatedAt { get; set; }
  }
}