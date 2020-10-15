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
        Task<List<TweetDTO>> Tweets(List<string> users);

        Task<bool> Delete(int tweetId);
        Task<bool> Subscribe(string userId);
        Task<bool> DeleteSubscribe(string userId);

        Task<List<SubscriptionDTO>> Subscriptions();
        Task<bool> DeleteSubscriptions(List<int> subscriptions);
    }
}