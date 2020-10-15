using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class TwitterService : ITwitterService
    {
        
        private readonly ILogger<TwitterService> logger;
        private readonly ApplicationDbContext context;

        public TwitterService(ILogger<TwitterService> logger, ApplicationDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }
        public List<Tweet> UserPosts(int userId)
        {
            var userPosts = context.Tweets.Where(p => p.IdentityUser.Id == userId.ToString()).ToList();
            return userPosts;
        }

        public ApplicationUser HelloWorld(int value)
        {
            
            

            return null;
        }
    }
}
