using Auth.Models;
using Auth.Repositories;
using Auth.Services;
using Auth.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Auth.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UserViewModel> Authenticate([FromBody] User user)
        {
            UserViewModel userViewModel = new UserViewModel();

            try
            {
                userViewModel.User = new UserRepository().Get(user);

                if (userViewModel.User == null)
                {
                    return NotFound("User not found!");
                }

                userViewModel.User.Password = null;

                userViewModel.Token = new TokenGenerator().Generate(userViewModel.User);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return userViewModel;
        }
    }
}
