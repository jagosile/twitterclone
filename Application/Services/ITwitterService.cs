using Application.DTO.Account;
using Domain.Model;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITwitterService
    {
        Task<bool> CreateTweet(CreateTweetRequest createTweetRequest);
    }
}