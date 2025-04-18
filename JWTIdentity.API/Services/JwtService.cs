using JWTIdentity.API.Entities;
using jwt= JWTIdentity.API.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace JWTIdentity.API.Services
{
    public class JwtService(IOptions<jwt.TokenOptions> tokenOptions, UserManager<AppUser> _userManager) : IJwtService
    {
        private readonly jwt.TokenOptions _tokenOptions = tokenOptions.Value;
        

        public async Task<string> CreateTokenAsync(AppUser user)
        {
            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_tokenOptions.Key));

            var userRoles = await _userManager.GetRolesAsync(user);

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,userRoles.FirstOrDefault()),
                new Claim("fullName",String.Join(" ",user.Name,user.Surname)),
            };

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(_tokenOptions.ExpireInMinutes),
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );

            JwtSecurityTokenHandler handler = new();

            var token = handler.WriteToken(jwtSecurityToken);

            return token;


        }
    }
}
