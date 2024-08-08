using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.repositories;
using DTO.DTOs.AboutDtos;
using DTO.DTOs.BlogDtos;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthorAboutManager : IAuthorAboutService
    {
        private readonly IAuthorAboutRepository _aboutRepository;
        private readonly IMapper _mapper;
        public AuthorAboutManager(IAuthorAboutRepository aboutRepository, IMapper mapper)
        {
            _aboutRepository = aboutRepository;
            _mapper = mapper;
        }

        public async Task<bool> TCreateAboutAsync(CreateAboutDto createAboutDto)
        {
          var about=_mapper.Map<AuthorAbout>(createAboutDto);
            return await _aboutRepository.CreateAsync(about);
        }

        public async Task<bool> TDeleteAboutAsync(int id)
        {
            return await _aboutRepository.DeleteAsync(id);
        }

        public async Task<AboutDto> TGetAboutByAuthorIdAsync(int authorId)
        {
            var about = await _aboutRepository.GetAboutByAuthorIdAsync(authorId);
            return _mapper.Map<AboutDto>(about);

        }

        public async Task<AboutDto> TGetAboutByIdAsync(int id)
        {
            var about  = await _aboutRepository.GetByIdAsync(id);
            return _mapper.Map<AboutDto>(about);
        }

        public async Task<IEnumerable<AboutDto>> TGetAllAboutAsync()
        {
          var abouts =await _aboutRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AboutDto>>(abouts);
        }

        public async Task<bool> TUpdateAboutAsync(UpdateAboutDto updateAboutdto)
        {
            var about = _mapper.Map<AuthorAbout>(updateAboutdto);
            return await _aboutRepository.UpdateAsync(about);
        }
    }
}
