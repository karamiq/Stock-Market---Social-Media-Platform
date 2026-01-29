
using api.Dtos.Stock;
using api.Helpers;
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
public async Task<List<Stock>> GetAllAsync(QueryObject query)
{
    var stocks = _context.Stocks.Include(s => s.Comments).AsQueryable();
    if (!string.IsNullOrEmpty(query.symbol))
    {
        stocks = stocks.Where(s => s.Symbol.Contains(query.symbol));
    }
    if (!string.IsNullOrEmpty(query.companyName))
    {
        stocks = stocks.Where(s => s.CompanyName.Contains(query.companyName));
    }
    if (!string.IsNullOrEmpty(query.sortBy))
    {

        switch (query.sortBy)
        {
            case "symbol":
                stocks = query.isDecending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                break;
            case "companyName":
                stocks = query.isDecending ? stocks.OrderByDescending(s => s.CompanyName) : stocks.OrderBy(s => s.CompanyName);
                break;
            case "marketCap":
                stocks = query.isDecending ? stocks.OrderByDescending(s => s.MarketCap) : stocks.OrderBy(s => s.MarketCap);
                break;
            default:
                break;
        }
    }
    stocks = stocks.Skip((query.pageNumber - 1) * query.pageSize).Take(query.pageSize);
    return await stocks.ToListAsync();
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