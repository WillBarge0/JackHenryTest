using CodingChallenge.Services;
using Reddit;

namespace CodingChallenge.Reddit
{
    public interface IRedditWrapper
    {
        Task<RedditClient> GetClientAsync();
    }

    public class RedditWrapper : IRedditWrapper
    {
        private readonly ISecretService _secretService;

        public RedditWrapper(ISecretService secretService)
        {
            _secretService = secretService ?? throw new ArgumentNullException(nameof(secretService));
        }

        public async Task<RedditClient> GetClientAsync()
        {
            RedditClient client = new RedditClient(await _secretService.GetAppIdAsync(),await _secretService.GetRefreshTokenAsync(),userAgent:"TestApplication");
            return client;
        }

    }
}