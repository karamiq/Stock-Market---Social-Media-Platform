using api.Dtos.Stock;
using api.interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly Data.ApplicationDBContext _context;

        public StockRepository(Data.ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                return false;
            }
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.Include(s => s.Comments).ToListAsync();
        }
        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updatedStock)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return null;
            }
            stock.Symbol = updatedStock.Symbol;
            stock.CompanyName = updatedStock.CompanyName;
            stock.purchase = updatedStock.purchase;
            stock.LatDiv = updatedStock.LatDiv;
            stock.industry = updatedStock.industry;
            stock.MarketCap = updatedStock.MarketCap;
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<bool> StockExists(int stockId)
        {
            return await _context.Stocks.AnyAsync(s => s.Id == stockId);
        }
    }


}