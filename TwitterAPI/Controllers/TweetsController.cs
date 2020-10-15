using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.DTO;
using Application.DTO.Account;
using Application.Services;
using Domain.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace TwitterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TweetsController : ControllerBase
    {

        private readonly ILogger<TweetsController> _logger;
        private readonly ITwitterService _twitterService;



        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;

        public TweetsController(ILogger<TweetsController> logger, ITwitterService twitterService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _twitterService = twitterService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet("{userId}", Name = "subscribe")]
        public async Task<ActionResult> Subscribe(string userId)
        {
            await Task.Delay(100);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<IdentityResult>> Create([FromBody] CreateUserRequest createUserRequest)
        {
            await Task.Delay(100);
            return Ok();
        }

        [HttpGet("{tweetId}", Name = "delete")]
        public async Task<ActionResult<IdentityResult>> Delete(int tweetId)
        {
            await Task.Delay(100);
            return Ok();
        }




    }


}
