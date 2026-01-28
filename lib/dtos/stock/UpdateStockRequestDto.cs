namespace api.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
           public string Symbol { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public decimal purchase { get; set; }
    public decimal LatDiv { get; set; }

    public string industry { get; set; } = string.Empty;
    public long MarketCap { get; set; }
    }
}