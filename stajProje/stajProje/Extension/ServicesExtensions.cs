using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.concrete;
using DataAccess.repositories;
using Entities.concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace stajProje.Extension
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
            
            options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
            
        }
     
        public static void AddServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
         
           
            services.AddScoped<IBlogRepository,BlogRepository>();
            services.AddScoped<IBlogService, BlogManager>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactService,ContactManager>();

            services.AddScoped<IAuthorAboutRepository, AuthorAboutRepository>();
            services.AddScoped<IAuthorAboutService,AuthorAboutManager>();

            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentService, CommentManager>();

            services.AddScoped<IUserService, UserService>();        

        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, Role>(opts =>
            {
                opts.User.RequireUniqueEmail = true;

            }
            )
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();
        }
        public static void ConfigureJwt(this IServiceCollection services,IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


            })
                .AddJwtBearer(options=>
                options.TokenValidationParameters=new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))    
                }
                );

        }
    }
}
