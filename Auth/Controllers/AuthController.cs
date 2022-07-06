using Auth.Models;
using Auth.Repositories;
using Auth.Services;
using Auth.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Auth.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UserViewModel> Auth([FromBody] User user)
        {
            UserViewModel userViewModel = new UserViewModel();

            try
            {
                userViewModel.User = new UserRepository().Get(user);

                if (userViewModel.User == null)
                {
                    return NotFound("User not found!");
                }

                userViewModel.Token = new TokenService(_config).Generate(userViewModel.User);

                userViewModel.User.Password = null;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return userViewModel;
        }
    }
}
