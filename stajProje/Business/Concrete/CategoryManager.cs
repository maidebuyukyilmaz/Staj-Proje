using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.repositories;
using DTO.DTOs.BlogDtos;
using DTO.DTOs.CategoryDtos;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager(ICategoryRepository _categoryRepository, IMapper _mapper) : ICategoryService
    {
     

        public async Task<bool> TCreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category=_mapper.Map<Category>(createCategoryDto);
            return await _categoryRepository.CreateAsync(category);
        }

        public async Task<bool> TDeleteCategoryAsync(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryDto>> TGetAllCategoriesAsync()
        {
            var categories  = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> TGetCategoryByIdAsync(int id)
        {
           var category=await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> TUpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
           var category= _mapper.Map<Category>(updateCategoryDto);
            return await _categoryRepository.UpdateAsync(category);
        }
    }
}
