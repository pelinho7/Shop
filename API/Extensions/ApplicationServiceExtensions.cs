using API.DBAccess.Data;
using API.Helpers;
using AutoMapper;
using API.DBAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using API.Services.Interfaces;
using API.Services;
using API.Interfaces;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config){
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IAgreementRepository,AgreementRepository>();
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<IEmailService,EmailService>();
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<IPhotoService,PhotoService>();
            services.AddScoped<ICreateHistoryService,CreateHistoryService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options=>{
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        } 
    }
}