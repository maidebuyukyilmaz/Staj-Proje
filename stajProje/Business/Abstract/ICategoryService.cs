using DTO.DTOs.AboutDtos;
using DTO.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICategoryService
    {
        Task<bool> TCreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<bool> TUpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<bool> TDeleteCategoryAsync(int id);
        Task<CategoryDto> TGetCategoryByIdAsync(int id);
        Task<IEnumerable<CategoryDto>> TGetAllCategoriesAsync();
    }
}
