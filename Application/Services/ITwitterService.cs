using Application.DTO;
using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITwitterService
    {
        Task<bool> CreateTweet(CreateTweetRequest createTweetRequest);

        Task<List<TweetDTO>> Tweets();

        Task<bool> DeleteTweet(int tweetId);

    }
}