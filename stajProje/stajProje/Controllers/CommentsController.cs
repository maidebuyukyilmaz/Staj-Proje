using Business.Abstract;
using DTO.DTOs.CommentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace stajProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(ICommentService _commentService) : ControllerBase
    {
        [Authorize(Roles ="user,author")]
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            var result = await _commentService.TCreateCommentAsync(createCommentDto);
            if (result)
            {
                return Ok("Comment created successfully.");
            }
            return BadRequest("Failed to create comment.");
        }
        [Authorize(Roles = "user,author")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var result = await _commentService.TDeleteCommentAsync(id);
            if (result)
            {
                return Ok("Comment deleted successfully.");
            }
            return NotFound("Failed to delete comment.");
        }
        [Authorize(Roles = "user,author")]
        [HttpGet("by-blog/{blogId}")]
        public async Task<IActionResult> GetCommentsByBlogId(int blogId)
        {
            var comments = await _commentService.TGetCommentsByBlogIdAsync(blogId);
            return Ok(comments);
        }
        [Authorize(Roles = "user,author")]
        [HttpGet("replies/{commentId}")]
        public async Task<IActionResult> GetRepliesByCommentId(int commentId)
        {
        var replies =await _commentService.TGetRepliesByCommentIdAsync(commentId);
            return Ok(replies);
        }
        [Authorize(Roles = "user,author")]
        [HttpPost("reply")]
        public async Task<IActionResult> ReplyToComment(ReplyToCommentDto replyToCommentDto)
        {
            var result = await _commentService.TReplyToCommentAsync(replyToCommentDto);
            if (result)
            {
                return Ok("Reply created successfully.");
            }
            return BadRequest("Failed to create reply.");
        }
        [Authorize(Roles = "user,author")]
        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            var result = await _commentService.TUpdateCommentAsync(updateCommentDto);
            if (result)
            {
                return Ok("Comment updated successfully.");
            }
            return BadRequest("Failed to update comment.");
        }
    }
}
