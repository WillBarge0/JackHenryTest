// ***********************************************************************
// Assembly         : CodingChallenge
// Author           : Bill Barge
// Created          : 09-03-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 09-03-2023
// ***********************************************************************
// <copyright file="ISecretService.cs" company="CodingChallenge">
//     Copyright (c) N/A. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CodingChallenge.Services;

/// <summary>
/// Interface ISecretService
/// </summary>
public interface ISecretService
{
    /// <summary>
    /// Gets the refresh token asynchronous.
    /// </summary>
    /// <returns>Task&lt;System.String&gt;.</returns>
    Task<string> GetRefreshTokenAsync();

    /// <summary>
    /// Gets the application identifier asynchronous.
    /// </summary>
    /// <returns>Task&lt;System.String&gt;.</returns>
    Task<string> GetAppIdAsync();
}