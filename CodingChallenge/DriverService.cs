using System.Text;
using CodingChallenge.Data.Repos;
using CodingChallenge.Reddit;
using CodingChallenge.Services;
using Reddit;
using Reddit.Controllers;
using CodingChallenge.Data.Model.DB_DTOs;
using DTO = CodingChallenge.Data.Model.DB_DTOs;
using Post = Reddit.Controllers.Post;
using Microsoft.Extensions.Hosting;

namespace CodingChallenge;

public class DriverService : IHostedService
{
    private readonly IOutputService _outputService;
    private readonly IRedditWrapper _redditWrapper;
    private readonly ICodingChallengeOptions _options;
    private readonly ISubRedditRepo _subRedditRepo;
    private bool _process;
    

    public DriverService(IHostApplicationLifetime applicationLifetime, IOutputService outputService,IRedditWrapper redditWrapper,ICodingChallengeOptions options,ISubRedditRepo subRedditRepo)
    {
        _outputService = outputService ?? throw new ArgumentNullException(nameof(outputService));
        _redditWrapper = redditWrapper ?? throw new ArgumentNullException( nameof(redditWrapper));
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _subRedditRepo = subRedditRepo ?? throw new ArgumentNullException(nameof(subRedditRepo));
    }



    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _outputService.SendOut($"Starting to monitor posts on the sub-reddit {_options.SubRedditToWatch}");

        RedditClient client = await _redditWrapper.GetClientAsync();


        //TODO - scale this to support multiple subreddits by moving this logic to an object passing in the client and the name of the subreddit you want to monitor
        Subreddit programmerHumor = client.Subreddit(_options.SubRedditToWatch).About();

        programmerHumor.Posts.MonitorNew();
        programmerHumor.Posts.NewUpdated += Posts_NewUpdated;

        while (cancellationToken.IsCancellationRequested == false)
        {
            try
            {
                await Task.Delay(TimeSpan.FromMinutes(2), cancellationToken);
            }
            catch
            {
            } //suppress the throw when the service is stopped with a ctrl-c

            DTO.Post[] posts = _subRedditRepo.GetPostsWithMostUpVotes(_options.ResultSetSize).ToArray<DTO.Post>();
            string[] users = _subRedditRepo.GetUsersWithMostPosts(_options.ResultSetSize).ToArray<string>();
            //TODO move this display logic to a presenter object(s)
            StringBuilder sb = new StringBuilder();
            sb.Append("Posts with the most up votes:");
            for (int counter = 0; counter < posts.Length; counter++)
            {
                DTO.Post post = posts[counter];
                sb.Append($"Post #{counter+1}");
                sb.AppendLine();
                sb.Append($"Title {post.Title}");
                sb.AppendLine();
                sb.Append($"Author {post.Author}");
                sb.AppendLine();
                sb.Append($"with a up vote count of {post.UpVoteCount}");
                sb.AppendLine();
            }
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("Users with the most posts:");
            for (int counter = 0; counter < users.Length; counter++)
            {
                sb.AppendLine();
                string user = users[counter];
                sb.Append($"User #{counter+1} {user}");
            }
            sb.AppendLine();
            sb.AppendLine();
            _outputService.SendOut(sb.ToString());
        }

        programmerHumor.Posts.MonitorNew();
        programmerHumor.Posts.NewUpdated -= Posts_NewUpdated;

    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
    
    private void Posts_NewUpdated(object? sender, global::Reddit.Controllers.EventArgs.PostsUpdateEventArgs e)
    {
        if (e.Added is { Count: > 0 })
        {
            foreach (DTO.Post localPost in e.Added.Select(post => new DTO.Post(post.Title, post.Author, post.UpVotes)))
            {
                _subRedditRepo.SetPost(localPost);
            }
        }
    }


}