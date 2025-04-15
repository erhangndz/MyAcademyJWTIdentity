using JWTIdentity.API.Entities;
using JWTIdentity.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWTIdentity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserManager<AppUser> _userManager) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var user = new AppUser
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Kullanıcı Kaydı Başarılı");
        }

    }
}
