// ***********************************************************************
// Assembly         : CodingChallenge
// Author           : Bill Barge
// Created          : 09-03-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 09-03-2023
// ***********************************************************************
// <copyright file="SubRedditRepo.cs" company="CodingChallenge">
//     Copyright (c) N/A. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CodingChallenge.Data.Model.DB_DTOs;

namespace CodingChallenge.Data.Repos;

/// <summary>
/// Class SubRedditRepo.
/// Implements the <see cref="CodingChallenge.Data.Repos.ISubRedditRepo" />
/// </summary>
/// <seealso cref="CodingChallenge.Data.Repos.ISubRedditRepo" />
public class SubRedditRepo : ISubRedditRepo
{
    /// <summary>
    /// The sub
    /// </summary>
    private readonly Sub _sub;
    /// <summary>
    /// The instance
    /// </summary>
    private static SubRedditRepo _instance = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="SubRedditRepo"/> class.
    /// </summary>
    /// <param name="subName">Name of the sub.</param>
    /// <exception cref="System.ArgumentNullException">subName</exception>
    private SubRedditRepo(string subName)
    {
        if (string.IsNullOrEmpty(subName))
        {
            throw new ArgumentNullException(nameof(subName));
        }
        _sub = new Sub(subName);
    }

    /// <summary>
    /// Gets the repo.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>ISubRedditRepo.</returns>
    /// <exception cref="System.ArgumentNullException">name</exception>
    public static ISubRedditRepo GetRepo(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }
        return _instance ??= new SubRedditRepo(name);
    }

    /// <summary>
    /// Adds the post.
    /// </summary>
    /// <param name="post">The post.</param>
    private void AddPost(Post post)
    {
        _sub.Posts.Add(post);
    }

    /// <summary>
    /// Sets the post.
    /// </summary>
    /// <param name="postToUpdate">The post to update.</param>
    public void SetPost(Post postToUpdate)
    {
        Post? post = _sub.Posts.FirstOrDefault(post => post.Title == postToUpdate.Title && post.Author == postToUpdate.Author);
        if (post != null)
        {
            post.UpVoteCount = postToUpdate.UpVoteCount;
        }
        else
        {
            AddPost(postToUpdate);
        }
    }

    /// <summary>
    /// Removes all post.
    /// </summary>
    public void RemoveAllPost()
    {
        _sub.Posts.Clear();
    }

    /// <summary>
    /// Gets all posts.
    /// </summary>
    /// <returns>IEnumerable&lt;Post&gt;.</returns>
    public IEnumerable<Post> GetAllPosts()
    {
        return _sub.Posts;
    }

    /// <summary>
    /// Gets the posts with the most up votes.
    /// </summary>
    /// <param name="numberOfTopResults">The number of top results.</param>
    /// <returns>IEnumerable&lt;Post&gt;.</returns>
    public IEnumerable<Post> GetPostsWithMostUpVotes(int numberOfTopResults)
    {
        return _sub.Posts.OrderByDescending(post => post.UpVoteCount).Take(numberOfTopResults);
    }

    /// <summary>
    /// Gets the users with most posts.
    /// </summary>
    /// <param name="numberOfTopResults">The number of top results.</param>
    /// <returns>IEnumerable&lt;System.String&gt;.</returns>
    public IEnumerable<string> GetUsersWithMostPosts(int numberOfTopResults)
    {
        Dictionary<string,int> authorCount = new Dictionary<string,int>();
        foreach (Post subPost in _sub.Posts)
        {
            if (authorCount.TryGetValue(subPost.Author, out int count))
            {
                authorCount[subPost.Author] = count+1;
            }
            else
            {
                authorCount[subPost.Author] = 1;
            }
        }

        IEnumerable<string> result = authorCount.Keys.OrderByDescending(key => authorCount[key]).Take(numberOfTopResults);
        return result;
    }

}