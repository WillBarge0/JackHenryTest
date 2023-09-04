// ***********************************************************************
// Assembly         : CodingChallenge
// Author           : Bill Barge
// Created          : 09-03-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 09-03-2023
// ***********************************************************************
// <copyright file="Post.cs" company="CodingChallenge">
//     Copyright (c) N/A. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CodingChallenge.Data.Model.DB_DTOs;

/// <summary>
/// Class Post.
/// </summary>
public class Post
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Post"/> class.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="author">The author.</param>
    /// <param name="upVoteCount">Up vote count.</param>
    public Post(string title, string author, int upVoteCount)
    {
        Title = title;
        Author = author;
        UpVoteCount = upVoteCount;
    }

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>The title.</value>
    public string Title { get; set; }
    /// <summary>
    /// Gets or sets the author.
    /// </summary>
    /// <value>The author.</value>
    public string Author { get; set; }
    /// <summary>
    /// Gets or sets up vote count.
    /// </summary>
    /// <value>Up vote count.</value>
    public int UpVoteCount { get; set; }
}