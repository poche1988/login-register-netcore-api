using Domain.Entities;
using System.Threading.Tasks;

namespace Services.User
{
    public interface IReadUserService {
        Task<AppUser> CurrentUser();

        string CurrentUserId();
    }
}
