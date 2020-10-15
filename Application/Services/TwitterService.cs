using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.DTO.Account;
using Domain.Model;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class TwitterService : ITwitterService
    {

        private readonly ILogger<TwitterService> _logger;
        private readonly ApplicationDbContext _context;
        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TwitterService(ILogger<TwitterService> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Create(CreateTweetRequest createTweetRequest)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var tweet = new Tweet
            {
                IdentityUser = user,
                Message = createTweetRequest.Body,
                PostDate = createTweetRequest.Created
            };

            _context.Tweets.Add(tweet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }


            return true;


        }

        public async Task<List<TweetDTO>> Tweets()
        {

            var tweets = await _context.Tweets.Select(x => new TweetDTO
            {
                Id = x.Id,
                Message = x.Message,
                Created = x.PostDate,
                User = new UserDTO
                {
                    Id = x.IdentityUser.Id,
                    Email = x.IdentityUser.Email,
                    Bio = "hello world"
                }
            })
                .OrderByDescending(x => x.Created).ToListAsync();
            return tweets;
        }

        public async Task<bool> Delete(int tweetId)
        {
            var tweet = await _context.Tweets.FirstOrDefaultAsync(x => x.Id == tweetId);
            _context.Tweets.Remove(tweet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
            return true;
        }


        public async Task<bool> Subscribe(string userId)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var userToSubscribeTo = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var sub = new Subscription
            {
                IdentityUser = user,
                Subscriber = userToSubscribeTo
            };

            _context.Subscriptions.Add(sub);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
            return true;
        }
    }
}
