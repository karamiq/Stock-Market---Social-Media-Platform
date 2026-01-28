using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Purchase = stock.purchase,
                LatDiv = stock.LatDiv,
                Industry = stock.industry,
                MarketCap = stock.MarketCap,
                Comments = stock.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }
        public static Stock ToStockFromCreateDto(this CreateStockRequest stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                purchase = stockDto.purchase,
                LatDiv = stockDto.LatDiv,
                industry = stockDto.industry,
                MarketCap = stockDto.MarketCap
            };
        }
    }  
}