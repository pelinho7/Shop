using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.DBAccess.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager
            ,RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return; 

            // var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            // var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            // if (users == null) return;

            var roles = new List<AppRole>
            {
                new AppRole{Name = AppRoleEnum.Admin.ToString()},
                new AppRole{Name = AppRoleEnum.User.ToString()},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
            
            // foreach (var user in users)
            // {
            //     user.UserName = user.UserName.ToLower();
            //     await userManager.CreateAsync(user,"Pa$$w0rd");
            //     await userManager.AddToRoleAsync(user, "Member");
            // }
            var admin = new AppUser
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] {AppRoleEnum.Admin.ToString(), AppRoleEnum.User.ToString()});
        }

        public static async Task SeedAgreement(IUnitOfWork unitOfWork)
        {
            if (unitOfWork.AgreementRepository.Count()>0) return; 

            var agreementRegulations=new Agreement(){
                Type=(int)AgreementTypeEnum.Login,
                Contents="I declare that I have read the regulations and accept their content",
                Obligatory=true,
                Removable=false
            };

            var agreementMarketing=new Agreement(){
                Type=(int)AgreementTypeEnum.Login,
                Contents="I would like to receive marketing messages",
                Obligatory=false,
                Removable=true,
            };

            unitOfWork.AgreementRepository.AddAgreement(agreementRegulations);
            await unitOfWork.Complete();
            unitOfWork.AgreementRepository.AddAgreement(agreementMarketing);
            await unitOfWork.Complete();
        }
    }
}