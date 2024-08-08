using Business.Abstract;
using DTO.DTOs.BlogDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace stajProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController (IBlogService _blogService): ControllerBase
    {
        [Authorize(Roles = "Author")]
        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogDto createBlogDto)
        {
            var result = await _blogService.TCreateBlogAsync(createBlogDto);
            if (!result)
            {
                return BadRequest("Failed to create blog");
            }

            return Ok("Blog created successfully");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogdto updateBlogdto)
        {
            var result = await _blogService.TUpdateBlogAsync(updateBlogdto);
            if (!result)
            {
                return BadRequest("Failed to update blog");
            }

            return Ok("Blog updated successfully");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("update-activity")]
        public async Task<IActionResult> UpdateBlogActivity([FromBody] UpdateBlogActivityDto updateBlogActivityDto)
        {
            var result = await _blogService.TUpdateBlogActivityAsync(updateBlogActivityDto);
            if (!result)
            {
                return BadRequest("Failed to update blog activity");
            }

            return Ok("Blog activity updated successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var blog = await _blogService.TGetBlogByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

       
        [HttpGet("active/{id}")]
        public async Task<IActionResult> GetActiveBlogById(int id)
        {
            var blog = await _blogService.TGetActiveBlogByIdAsync(id);
            if (blog != null)
            {
                return Ok(blog);
            }
            return NotFound("Blog not found.");
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveBlogs()
        {
            var blogs = await _blogService.TGetActiveBlogsAsync();
            return Ok(blogs);
        }

        [HttpGet("active/by-author/{authorId}")]
        public async Task<IActionResult> GetActiveBlogsByAuthorId(int authorId)
        {
            var blogs = await _blogService.TGetActiveBlogsByAuthorIdAsync(authorId);
            return Ok(blogs);
        }

        [HttpGet("active/by-category/{categoryId}")]
        public async Task<IActionResult> GetActiveBlogsByCategoryId(int categoryId)
        {
            var blogs = await _blogService.TGetActiveBlogsByCategoryIdAsync(categoryId);
            return Ok(blogs);
        }
        [HttpGet("passive/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPassiveBlogById(int id)
        {
            var blog = await _blogService.TGetPassiveBlogByIdAsync(id);
            if (blog != null)
            {
                return Ok(blog);
            }
            return NotFound("Blog not found.");
        }

        [HttpGet("passive")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPassiveBlogs()
        {
            var blogs = await _blogService.TGetPassiveBlogsAsync();
            return Ok(blogs);
        }

      
       
    }
}

