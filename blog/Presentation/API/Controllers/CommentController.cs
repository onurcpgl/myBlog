using Application.DataTransferObject;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpPost("/comment")]
        public async Task<IActionResult> AddComment([FromBody] CommentDto commentDto)
        {
            var result = await _commentService.saveComment(commentDto);
            if (!result)
            {
                return BadRequest();
            }
            else
            {
                return Ok(true);
            }
        }

        [HttpGet("/comment")]
        public async Task<IActionResult> CommentList()
        {
            var result = await _commentService.CommentList();
            return Ok(result);

        }
        [HttpGet("/comment/{id}")]
        public async Task<IActionResult> GetArticleListById(int id)
        {
            var result = await _commentService.getCommentById(id);
            return Ok(result);
        }

    }
}
