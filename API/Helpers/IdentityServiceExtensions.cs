using System.Text;
using API.DBAccess.Data;
using API.DBAccess.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config){
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength=4;
                opt.Password.RequireDigit=false;
            })
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddRoleValidator<RoleValidator<AppRole>>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                    //na potrzeby signalR
                    options.Events=new JwtBearerEvents{
                        OnMessageReceived=context=>{
                            //pobieramy z rządania token
                            var accessToken=context.Request.Query["access_token"];
                            var path=context.HttpContext.Request.Path;
                            //jeżeli token jest nie pusty oraz scieżka aktualna zaczyna się od hubs to
                            //ustawiamy w kontekscie pobrany z rządania token
                            if(!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs")){
                                context.Token=accessToken;
                            }

                             return System.Threading.Tasks.Task.CompletedTask;
                        }
                    };
                });
            
            services.AddAuthorization(opt=>{
                opt.AddPolicy("RequireAdminRole",policy=>policy.RequireRole("Admin"));
            });

            return services;
        } 
    }
}