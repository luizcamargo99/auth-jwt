using Auth.Models;
using Auth.Repositories;
using Auth.Services;
using Auth.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Auth.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("noauth")]
        [Authorize]
        public string NoAuthRequiredMethod()
        {
            return "This method is free for everyone!";
        }

        [HttpGet]
        [Route("authrequired")]
        [Authorize]
        public string AuthRequiredMethod()
        {
            return "If you can see this, you have a token!";
        }

    }
}
