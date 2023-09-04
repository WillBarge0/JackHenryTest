// ***********************************************************************
// Assembly         : CodingChallenge
// Author           : Bill Barge
// Created          : 09-02-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 09-02-2023
// ***********************************************************************
// <copyright file="SecretService.cs" company="CodingChallenge">
//     Copyright (c) N/A. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CodingChallenge.Services;

/// <summary>
/// Class SecretService.
/// A service to get values that should be secured
/// </summary>
public class SecretService : ISecretService
{
    private readonly ICodingChallengeOptions _options;

    public SecretService(ICodingChallengeOptions options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// Gets the refresh token asynchronous.
    /// </summary>
    /// <returns>Task&lt;System.String&gt;.</returns>
    public Task<string> GetRefreshTokenAsync()
    {
        return Task.FromResult(_options.RefreshToken);
    }

    /// <summary>
    /// Gets the application identifier asynchronous.
    /// </summary>
    /// <returns>Task&lt;System.String&gt;.</returns>
    public Task<string> GetAppIdAsync()
    {
        return Task.FromResult(_options.AppId);
    }
}