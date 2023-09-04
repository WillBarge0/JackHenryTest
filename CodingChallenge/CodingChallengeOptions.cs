// ***********************************************************************
// Assembly         : CodingChallenge
// Author           : Bill Barge
// Created          : 09-03-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 09-03-2023
// ***********************************************************************
// <copyright file="CodingChallengeOptions.cs" company="CodingChallenge">
//     Copyright (c) N/A. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CodingChallenge;

/// <summary>
/// Interface ICodingChallengeOptions
/// </summary>
public interface ICodingChallengeOptions
{
    /// <summary>
    /// Gets or sets the sub reddit to watch.
    /// </summary>
    /// <value>The sub reddit to watch.</value>
    string SubRedditToWatch { get; set; }
    /// <summary>
    /// Gets or sets the application identifier.
    /// </summary>
    /// <value>The application identifier.</value>
    string AppId { get; set; }
    /// <summary>
    /// Gets or sets the refresh token.
    /// </summary>
    /// <value>The refresh token.</value>
    string RefreshToken { get; set; }
    /// <summary>
    /// Gets or sets the size of the result set.
    /// </summary>
    /// <value>The size of the result set.</value>
    int ResultSetSize { get; set; }
}

/// <summary>
/// Class CodingChallengeOptions.
/// Implements the <see cref="CodingChallenge.ICodingChallengeOptions" />
/// </summary>
/// <seealso cref="CodingChallenge.ICodingChallengeOptions" />
public class CodingChallengeOptions : ICodingChallengeOptions
{
    /// <summary>
    /// Gets or sets the sub reddit to watch.
    /// </summary>
    /// <value>The sub reddit to watch.</value>
    public string SubRedditToWatch { get; set; } = null!;
    /// <summary>
    /// Gets or sets the application identifier.
    /// </summary>
    /// <value>The application identifier.</value>
    public string AppId { get; set; } = null!;
    /// <summary>
    /// Gets or sets the refresh token.
    /// </summary>
    /// <value>The refresh token.</value>
    public string RefreshToken { get; set; } = null!;
    /// <summary>
    /// Gets or sets the size of the result set.
    /// </summary>
    /// <value>The size of the result set.</value>
    public int ResultSetSize { get; set; }
}