using DTO.DTOs.AboutDtos;

using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IAuthorAboutService
    {
        Task<AboutDto> TGetAboutByAuthorIdAsync(int authorId);
    
        Task<bool> TCreateAboutAsync(CreateAboutDto createAboutDto);
        Task<bool> TUpdateAboutAsync(UpdateAboutDto updateAboutdto);
        Task<bool> TDeleteAboutAsync(int id);
        Task<AboutDto> TGetAboutByIdAsync(int id);
        Task<IEnumerable<AboutDto>> TGetAllAboutAsync();
    }
}
