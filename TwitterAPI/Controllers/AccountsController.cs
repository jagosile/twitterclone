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
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace TwitterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountsController : ControllerBase
    {

        private readonly ILogger<AccountsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ITwitterService _twitterService;
        private readonly ApplicationDbContext _context;



        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;

        public AccountsController(ILogger<AccountsController> logger, IConfiguration configuration, ITwitterService twitterService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _twitterService = twitterService;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

         [HttpGet]
        public async Task<ActionResult<ApplicationUser>> Authenticated()
        {
            var username = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var user = await _context.Users
                .Select(x => new ApplicationUser { Id = x.Id, Email = x.Email, Name = x.UserName })
                .FirstOrDefaultAsync(x => x.Name == username);


            var claims = await (from uc in _context.UserClaims
                                where uc.UserId == user.Id
                                select Int32.Parse(uc.ClaimValue)).ToListAsync();

            return user;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Login(LoginRequest loginRequest)
        {
           var result = await _signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, true, true);
            if (result.Succeeded)
            {
                var token = BuildToken(loginRequest);
                return token;
            };
            return Unauthorized();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<IdentityResult>> Create([FromBody] CreateUserRequest createUserRequest)
        {
            var identityUser = new IdentityUser
            {
                Email = createUserRequest.Email,
                UserName = createUserRequest.Email,
            };
            var result = await _userManager.CreateAsync(identityUser, createUserRequest.Password);
            return result;
        }

        public class UserToken
        {
            public string Token { get; set; }
            public DateTime Expiration { get; set; }
        }

        private UserToken BuildToken(ILoginRequest loginRequest)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, loginRequest.Email),
                new Claim(ClaimTypes.Email, loginRequest.Email),
                new Claim("mykey", "xyz")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.Now.AddYears(1);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }


    }


}
