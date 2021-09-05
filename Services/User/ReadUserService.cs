using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services.User
{
    public class ReadUserService : IReadUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public ReadUserService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)

        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<AppUser> CurrentUser()
        {
            return await _userManager.FindByIdAsync(CurrentUserId());
        }

        public string CurrentUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
