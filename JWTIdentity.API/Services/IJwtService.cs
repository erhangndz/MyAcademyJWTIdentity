using JWTIdentity.API.Entities;

namespace JWTIdentity.API.Services
{
    public interface IJwtService
    {

        Task<string> CreateTokenAsync(AppUser user);

    }
}
