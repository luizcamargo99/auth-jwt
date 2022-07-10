using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("public")]
        [AllowAnonymous]
        public string NoAuthRequiredMethod()
        {
            return "This method is free for everyone!";
        }

        [HttpGet]
        [Route("private")]
        [Authorize]
        public string AuthRequiredMethod()
        {
            return $"Hi, {User.Identity.Name}. If you can see this, you have a token!";
        }

    }
}
