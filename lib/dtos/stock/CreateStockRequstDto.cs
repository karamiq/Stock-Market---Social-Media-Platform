using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Stock
{
    public class CreateStockRequest
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot exceed 10 characters.")]
        [MinLength(1, ErrorMessage = "Symbol must be at least 1 character long.")]
        
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Company Name cannot exceed 100 characters.")]
        [MinLength(1, ErrorMessage = "Company Name must be at least 1 character long.")]
    public string CompanyName { get; set; } = string.Empty;
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Purchase price must be greater than 0.")]
    
    public decimal purchase { get; set; }
    [Required]
    [Range(0.0, double.MaxValue, ErrorMessage = "Latest Dividend cannot be negative.")]
    public decimal LatDiv { get; set; }
    [Required]
    [MaxLength(50, ErrorMessage = "Industry cannot exceed 50 characters.")]
    public string industry { get; set; } = string.Empty;
    [Required]
    [Range(0, long.MaxValue, ErrorMessage = "Market Cap cannot be negative.")]
    public long MarketCap { get; set; }
    }
}