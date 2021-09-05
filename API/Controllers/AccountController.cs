using API.Authentication;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Account;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Private Members

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        #endregion


        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> Login(LoginModel loginModel)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email);

                if (user == null) return Unauthorized();

                var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);

                if (result.Succeeded)
                {
                    return CreateUserModel(user);
                }

                return Unauthorized();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> Register(RegisterModel registerModel)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerModel.Email))
            {
                return BadRequest("Email taken");
            }

            if (ModelState.IsValid)
            {
                var user = _mapper.Map<RegisterModel, AppUser>(registerModel);

                var result = await _userManager.CreateAsync(user, registerModel.Password);

                if (result.Succeeded)
                {
                    return new UserModel
                    {
                        Id = user.Id,
                        DisplayName = user.DisplayName,
                        Token = _tokenService.CreateToken(user),
                        Username = user.UserName
                    };
                }
            }

            return BadRequest("Problems registering user");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserModel>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return CreateUserModel(user);
        }

        #region Private Methods

        private ActionResult<UserModel> CreateUserModel(AppUser user)
        {
            return new UserModel
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName
            };
        }

        #endregion
    }
}
