using AutoMapper;
using DTO.DTOs.AboutDtos;
using DTO.DTOs.BlogDtos;
using DTO.DTOs.CategoryDtos;
using DTO.DTOs.CommentDtos;
using DTO.DTOs.ContactDtos;
using DTO.DTOs.UserDtos;
using Entities.concrete;

namespace stajProje.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationDto, User>();
            CreateMap<LoginDto, User>();
            CreateMap<UpdateUserDto, User>().ReverseMap();
            CreateMap<UpdateUserRoleDto, User>().ReverseMap();
            CreateMap<ChangePasswordDto, User>().ReverseMap();
            CreateMap<UserDto,User>().ReverseMap();
           

            CreateMap<BlogDto, Blog>().ReverseMap();
            CreateMap<CreateBlogDto, Blog>().ReverseMap();
            CreateMap<UpdateBlogdto, Blog>().ReverseMap();
            CreateMap<UpdateBlogActivityDto, Blog>().ReverseMap();

            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto,Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
           
            CreateMap<CreateAboutDto,AuthorAbout>().ReverseMap();
            CreateMap<UpdateAboutDto, AuthorAbout>().ReverseMap();
            CreateMap<AboutDto, AuthorAbout>().ReverseMap();

            CreateMap<CreateContactDto, Contact>()
          .ForMember(dest => dest.SentDate, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<ContactDto, Contact>().ReverseMap();

           CreateMap<CommentDto,Comment>().ReverseMap();
            CreateMap<CreateCommentDto, Comment>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<UpdateCommentDto, Comment>().ReverseMap();
            CreateMap<ReplyToCommentDto,Comment>()
                 .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now));

        }
    }
}
