using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.DTO;
using Application.Services;
using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TwitterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountsController : ControllerBase
    {

        private readonly ILogger<AccountsController> _logger;
        private readonly ITwitterService _twitterService;

        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;

        public AccountsController(ILogger<AccountsController> logger, ITwitterService twitterService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _twitterService = twitterService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult<Microsoft.AspNetCore.Identity.SignInResult>> Login(IdentityUserDTO identityUserDTO)
        {
           var result = await _signInManager.PasswordSignInAsync(identityUserDTO.Email, identityUserDTO.Password, true, true);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<IdentityResult>> Create([FromBody] IdentityUserDTO identityUserDTO)
        {
            var applicationUser = new IdentityUser
            {
                Email = identityUserDTO.Email,
                UserName = identityUserDTO.Email,
            };
            var result = await _userManager.CreateAsync(applicationUser, identityUserDTO.Password);
            return result;
        }



    }


}
