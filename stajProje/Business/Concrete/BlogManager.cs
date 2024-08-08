using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DTO.DTOs.BlogDtos;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public BlogManager(IBlogRepository blogRepository,IMapper mapper) 
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<bool> TCreateBlogAsync(CreateBlogDto createBlogDto)
        {
            var blog = _mapper.Map<Blog>(createBlogDto);
            return await _blogRepository.CreateAsync(blog);
        }

        public async Task<bool> TDeleteBlogAsync(int id)
        {
            return await _blogRepository.DeleteAsync(id);
        }

        public async Task<BlogDto> TGetActiveBlogByIdAsync(int Blogid)
        {
            var blog = await _blogRepository.GetActiveBlogByIdAsync(Blogid);
            return _mapper.Map<BlogDto>(blog);
        }

        public async Task<List<BlogDto>> TGetActiveBlogsAsync()
        {
            var blogs = await _blogRepository.GetActiveBlogsAsync();
            return _mapper.Map<List<BlogDto>>(blogs);
        }

        public async Task<IEnumerable<BlogDto>> TGetActiveBlogsByAuthorIdAsync(int authorId)
        {
            var blogs = await _blogRepository.GetActiveBlogsByAuthorIdAsync(authorId);
            return _mapper.Map<IEnumerable<BlogDto>>(blogs);
        }

        public async Task<IEnumerable<BlogDto>> TGetActiveBlogsByCategoryIdAsync(int categoryId)
        {
            var blogs = await _blogRepository.GetActiveBlogsByCategoryIdAsync(categoryId);
            return _mapper.Map<IEnumerable<BlogDto>>(blogs);
        }

       

        public async Task<BlogDto> TGetBlogByIdAsync(int id)
        {
            var blogs = await _blogRepository.GetByIdBlogsAsync(id);
            return _mapper.Map<BlogDto>(blogs);
        }

        public async Task<IEnumerable<BlogDto>> TGetBlogsByAuthorIdAsync(int authorId)
        {
            var blogs = await _blogRepository.GetBlogsByAuthorIdAsync(authorId);
            return _mapper.Map<IEnumerable<BlogDto>>(blogs);
        }

        public async Task<IEnumerable<BlogDto>> TGetBlogsByCategoryIdAsync(int categoryId)
        {
            var blogs = await _blogRepository.GetBlogsByCategoryIdAsync(categoryId);
            return _mapper.Map<IEnumerable<BlogDto>>(blogs);
        }

       
        public async Task<BlogDto> TGetPassiveBlogByIdAsync(int Blogid)
        {
            var blog = await _blogRepository.GetPassiveBlogByIdAsync(Blogid);
            return _mapper.Map<BlogDto>(blog);
        }

        public async Task<IEnumerable<BlogDto>> TGetPassiveBlogsAsync()
        {
            var blogs = await _blogRepository.GetPassiveBlogsAsync();
            return _mapper.Map<IEnumerable<BlogDto>>(blogs);
        }

        public async Task<bool> TUpdateBlogActivityAsync(UpdateBlogActivityDto updateBlogActivityDto)
        {
            var blog = await _blogRepository.GetByIdAsync(updateBlogActivityDto.Id);
            if (blog == null) return false;

            _mapper.Map(updateBlogActivityDto, blog);
            if (updateBlogActivityDto.IsActive && !updateBlogActivityDto.PublishedAt.HasValue)
            {
                blog.PublishedAt = DateTime.Now;
            }
            else if (updateBlogActivityDto.PublishedAt.HasValue)
            {
                blog.PublishedAt = updateBlogActivityDto.PublishedAt.Value;
            }
            blog.IsActive = updateBlogActivityDto.IsActive;

            return await _blogRepository.UpdateAsync(blog);
        }

        public async Task<bool> TUpdateBlogAsync(UpdateBlogdto updateBlogdto)
        {
            var blog = _mapper.Map<Blog>(updateBlogdto);
            return await _blogRepository.UpdateAsync(blog);
        }
    }
}
