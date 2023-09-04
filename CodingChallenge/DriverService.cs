// ***********************************************************************
// Assembly         : CodingChallenge
// Author           : Bill Barge
// Created          : 09-03-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 09-03-2023
// ***********************************************************************
// <copyright file="DriverService.cs" company="CodingChallenge">
//     Copyright (c) N/A. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text;
using CodingChallenge.Data.Repos;
using CodingChallenge.Reddit;
using CodingChallenge.Services;
using Reddit;
using Reddit.Controllers;
using DTO = CodingChallenge.Data.Model.DB_DTOs;
using Microsoft.Extensions.Hosting;

namespace CodingChallenge;

/// <summary>
/// Class DriverService.
/// Implements the <see cref="IHostedService" />
/// </summary>
/// <seealso cref="IHostedService" />
public class DriverService : IHostedService
{
    /// <summary>
    /// The output service
    /// </summary>
    private readonly IOutputService _outputService;
    /// <summary>
    /// The reddit wrapper
    /// </summary>
    private readonly IRedditWrapper _redditWrapper;
    /// <summary>
    /// The options
    /// </summary>
    private readonly ICodingChallengeOptions _options;
    private readonly ISubRedditRepo _subRedditRepo;

    /// <summary>
    /// Initializes a new instance of the <see cref="DriverService"/> class.
    /// </summary>
    /// <param name="outputService">The output service.</param>
    /// <param name="redditWrapper">The reddit wrapper.</param>
    /// <param name="options">The options.</param>
    /// <param name="subRedditRepo">The sub reddit repo.</param>
    public DriverService(IOutputService outputService,IRedditWrapper redditWrapper,ICodingChallengeOptions options,ISubRedditRepo subRedditRepo)
    {
        _outputService = outputService ?? throw new ArgumentNullException(nameof(outputService));
        _redditWrapper = redditWrapper ?? throw new ArgumentNullException( nameof(redditWrapper));
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _subRedditRepo = subRedditRepo ?? throw new ArgumentNullException(nameof(subRedditRepo));
    }

    /// <summary>
    /// Start as an asynchronous operation.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A Task&lt;System.Threading.Tasks.Task&gt; representing the asynchronous operation.</returns>
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
                // ignored
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

    /// <summary>
    /// Stops the asynchronous.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>System.Threading.Tasks.Task.</returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// Postses the new updated.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="Reddit.Controllers.EventArgs.PostsUpdateEventArgs"/> instance containing the event data.</param>
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