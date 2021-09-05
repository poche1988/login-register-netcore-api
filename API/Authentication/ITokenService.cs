using Domain.Entities;

namespace API.Authentication
{
    public interface ITokenService {
        string CreateToken(AppUser user);
    }
}
