// ***********************************************************************
// Assembly         : CodingChallenge
// Author           : Bill Barge
// Created          : 09-03-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 09-03-2023
// ***********************************************************************
// <copyright file="RedditWrapper.cs" company="CodingChallenge">
//     Copyright (c) N/A. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CodingChallenge.Services;
using Reddit;

namespace CodingChallenge.Reddit
{
    /// <summary>
    /// Interface IRedditWrapper
    /// </summary>
    public interface IRedditWrapper
    {
        /// <summary>
        /// Gets the client asynchronous.
        /// </summary>
        /// <returns>Task&lt;RedditClient&gt;.</returns>
        Task<RedditClient> GetClientAsync();
    }

    /// <summary>
    /// Class RedditWrapper.
    /// Implements the <see cref="CodingChallenge.Reddit.IRedditWrapper" />
    /// </summary>
    /// <seealso cref="CodingChallenge.Reddit.IRedditWrapper" />
    public class RedditWrapper : IRedditWrapper
    {
        /// <summary>
        /// The secret service
        /// </summary>
        private readonly ISecretService _secretService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedditWrapper"/> class.
        /// </summary>
        /// <param name="secretService">The secret service.</param>
        /// <exception cref="System.ArgumentNullException">secretService</exception>
        public RedditWrapper(ISecretService secretService)
        {
            _secretService = secretService ?? throw new ArgumentNullException(nameof(secretService));
        }

        /// <summary>
        /// Get client as an asynchronous operation.
        /// </summary>
        /// <returns>A Task&lt;RedditClient&gt; representing the asynchronous operation.</returns>
        public async Task<RedditClient> GetClientAsync()
        {
            RedditClient client = new RedditClient(await _secretService.GetAppIdAsync(),await _secretService.GetRefreshTokenAsync(),userAgent:"TestApplication");
            return client;
        }

    }
}