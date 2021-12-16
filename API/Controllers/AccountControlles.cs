using System.Threading.Tasks;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        public AccountController()
        {

        }

        //[HttpGet]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            if(loginDto==null)
                return BadRequest();

            return new UserDto(); 
        }
    }
}