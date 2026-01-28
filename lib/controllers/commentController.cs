using api.Mappers;
using api.Models;
using api.repositories;
using api.interfaces;
using api.dtos.comment;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;
        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var comments = await _commentRepository.GetAllCommentsAsync();
            var commentDtos = comments.Select(c => c.ToCommentDto());
            return Ok(commentDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            if (comment == null)
                return NotFound();
            var commentDto = comment.ToCommentDto();
            return Ok(commentDto);
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDto commentDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!await _stockRepository.StockExists(stockId))
            {
                return BadRequest($"Stock with ID {stockId} does not exist.");
            }
            var commentModel = commentDto.ToCommentFromCreateModel(stockId);
            var createdComment = await _commentRepository.CreateCommentAsync(commentModel);
            var createdCommentDto = createdComment.ToCommentDto();
            return CreatedAtAction(nameof(GetById), new { id = createdCommentDto.Id }, createdCommentDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto updateDto)
        {
            var updatedComment = await _commentRepository.UpdateCommentAsync(id, updateDto.ToCommentFromCreateModel(id));
            if (updatedComment == null)
                return NotFound("Comment not found.");
            return Ok(updatedComment.ToCommentDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _commentRepository.DeleteCommentAsync(id);

            if (deleted == null)
                return NotFound("Comment not found.");
            return Ok(deleted);
        }
    }
}
