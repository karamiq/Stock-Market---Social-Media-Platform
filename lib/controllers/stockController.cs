using api.Dtos.Stock;
using api.interfaces;
using api.Mappers;
using api.repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StockController: ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        public StockController(IStockRepository stockRepository)
        {

            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var stocks = await _stockRepository.GetAllAsync();
            var stockDtos = stocks.Select(s => s.ToStockDto());
            return Ok(stockDtos);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> getById([FromRoute] int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
        [HttpPost]
        public async Task<IActionResult> create([FromBody] CreateStockRequest stockDto)
        {
            var stock = stockDto.ToStockFromCreateDto();
            var createdStock = await _stockRepository.CreateAsync(stock);
            return CreatedAtAction(nameof(getById), new { id = createdStock.Id }, createdStock.ToStockDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDto)
        {
            var stockModel = await _stockRepository.GetByIdAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }

            stockModel.Symbol = stockDto.Symbol;
            stockModel.CompanyName = stockDto.CompanyName;
            stockModel.purchase = stockDto.purchase;
            stockModel.LatDiv = stockDto.LatDiv;
            stockModel.industry = stockDto.industry;
            stockModel.MarketCap = stockDto.MarketCap;

            var updatedStock = await _stockRepository.UpdateAsync(id, stockDto);
            if (updatedStock == null)
            {
                return NotFound();
            }
            return Ok(updatedStock.ToStockDto());
        }

                    [HttpDelete("{id:int}")]
        public async Task<IActionResult> delete([FromRoute] int id)
        {
            var stockModel = await _stockRepository.GetByIdAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }

            var deleted = await _stockRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}