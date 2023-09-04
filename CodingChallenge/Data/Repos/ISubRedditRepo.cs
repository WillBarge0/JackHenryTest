// ***********************************************************************
// Assembly         : CodingChallenge
// Author           : Bill Barge
// Created          : 09-03-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 09-03-2023
// ***********************************************************************
// <copyright file="ISubRedditRepo.cs" company="CodingChallenge">
//     Copyright (c) N/A. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CodingChallenge.Data.Model.DB_DTOs;

namespace CodingChallenge.Data.Repos;

/// <summary>
/// Interface ISubRedditRepo
/// </summary>
public interface ISubRedditRepo
{
    /// <summary>
    /// Sets the post.
    /// </summary>
    /// <param name="postToUpdate">The post to update.</param>
    void SetPost(Post postToUpdate);
    /// <summary>
    /// Removes all post.
    /// </summary>
    void RemoveAllPost();
    /// <summary>
    /// Gets all posts.
    /// </summary>
    /// <returns>IEnumerable&lt;Post&gt;.</returns>
    IEnumerable<Post> GetAllPosts();
    /// <summary>
    /// Gets the posts with most up votes.
    /// </summary>
    /// <param name="numberOfTopResults">The number of top results.</param>
    /// <returns>IEnumerable&lt;Post&gt;.</returns>
    IEnumerable<Post> GetPostsWithMostUpVotes(int numberOfTopResults);
    /// <summary>
    /// Gets the users with most posts.
    /// </summary>
    /// <param name="numberOfTopResults">The number of top results.</param>
    /// <returns>IEnumerable&lt;System.String&gt;.</returns>
    IEnumerable<string> GetUsersWithMostPosts(int numberOfTopResults);

}