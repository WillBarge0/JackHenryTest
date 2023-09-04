// ***********************************************************************
// Assembly         : CodingChallenge
// Author           : Bill Barge
// Created          : 09-03-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 09-03-2023
// ***********************************************************************
// <copyright file="Sub.cs" company="CodingChallenge">
//     Copyright (c) N/A. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CodingChallenge.Data.Model.DB_DTOs;

/// <summary>
/// Class Sub.
/// </summary>
public class Sub
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Sub"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <exception cref="System.ArgumentNullException">name</exception>
    public Sub(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Posts = new List<Post>();
    }
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets the posts associated with the sub.
    /// </summary>
    /// <value>The posts.</value>
    public ICollection<Post> Posts { get; set; }
}