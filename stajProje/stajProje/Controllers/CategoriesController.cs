using Business.Abstract;
using DTO.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace stajProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var result = await _categoryService.TCreateCategoryAsync(createCategoryDto);
            if (result)
            {
                return Ok("Category created successfully.");
            }
            return BadRequest("Failed to create category.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.TDeleteCategoryAsync(id);
            if (result)
            {
                return Ok("Category deleted successfully.");
            }
            return NotFound("Failed to delete category.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.TGetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.TGetCategoryByIdAsync(id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound("Category not found.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var result = await _categoryService.TUpdateCategoryAsync(updateCategoryDto);
            if (result)
            {
                return Ok("Category updated successfully.");
            }
            return BadRequest("Failed to update category.");
        }
    }
}
