using api.Dtos.Stock;
using api.Models;

namespace api.interfaces
{
    public interface IStockRepository
    {
      
        Task<List<Stock>> GetAllAsync();
          Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stock);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updatedStock);
        Task<bool> DeleteAsync(int id);

         Task<bool> StockExists(int stockId);
    }
    
}