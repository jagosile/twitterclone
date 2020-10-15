using Application.DTO;
using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITwitterService
    {
        Task<bool> Create(CreateTweetRequest createTweetRequest);

        Task<List<TweetDTO>> Tweets();

        Task<bool> Delete(int tweetId);
        Task<bool> Subscribe(string userId);

    }
}