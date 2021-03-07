using AzureUMAPI.Interfaces;
using AzureUMAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureUMAPI.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IAuthService authService, IUserService userService)
        {
            _logger = logger;
            _authService = authService;
            _userService = userService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<UsersResponse> GetAllUsers()
        {

            var token = await _authService.GetAccessToken();
            var users = await _userService.GetAllUsers(token);
            return users;
        }
    }
}
