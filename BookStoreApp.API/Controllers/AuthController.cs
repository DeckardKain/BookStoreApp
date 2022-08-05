using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;

        public AuthController(ILogger logger, IMapper mapper, UserManager<ApiUser> userManager)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register (UserDTO userDTO)
        {
            var user = _mapper.Map<ApiUser>(userDTO);
            var result = await _userManager.CreateAsync(user, userDTO.Password);

            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);

                }

                return BadRequest(ModelState);
            }

            await _userManager.AddToRoleAsync(user, "User");

            return Accepted();
        }



        /*public async Task<IActionResult> Login(string returnUrl)
        {

        }*/
    }
}
