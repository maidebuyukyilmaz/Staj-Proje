using DTO.DTOs.BlogDtos;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDto>> TGetBlogsByAuthorIdAsync(int authorId);
        Task<IEnumerable<BlogDto>> TGetBlogsByCategoryIdAsync(int categoryId);
        Task<bool> TUpdateBlogActivityAsync(UpdateBlogActivityDto blogUpdateActivityDTO);
        Task<bool> TCreateBlogAsync(CreateBlogDto createBlogDto);
        Task<bool> TUpdateBlogAsync(UpdateBlogdto updateBlogdto);
        Task<bool> TDeleteBlogAsync(int id); 
        Task<BlogDto> TGetBlogByIdAsync(int id);
     

        Task<IEnumerable<BlogDto>> TGetActiveBlogsByAuthorIdAsync(int authorId);
        Task<IEnumerable<BlogDto>> TGetActiveBlogsByCategoryIdAsync(int categoryId);
        Task<List<BlogDto>> TGetActiveBlogsAsync();
        Task<IEnumerable<BlogDto>> TGetPassiveBlogsAsync();
        Task<BlogDto> TGetActiveBlogByIdAsync(int Blogid);
        Task<BlogDto> TGetPassiveBlogByIdAsync(int Blogid);

    }
}
