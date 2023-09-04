// ***********************************************************************
// Assembly         : CodingChallenge
// Author           : Bill Barge
// Created          : 09-03-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 09-03-2023
// ***********************************************************************
// <copyright file="CompositionRoot.cs" company="CodingChallenge">
//     Copyright (c) N/A. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CodingChallenge.Data.Repos;
using CodingChallenge.Reddit;
using CodingChallenge.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodingChallenge;

/// <summary>
/// Class CompositionRoot.
/// </summary>
internal class CompositionRoot
{
    /// <summary>
    /// Configures the local objects.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="options">The options.</param>
    internal static void ConfigureLocalObjects(IServiceCollection services,ICodingChallengeOptions options)
    {
        // ReSharper disable once RedundantTypeArgumentsOfMethod
        services.AddSingleton<ICodingChallengeOptions>(options);//refactor to use built-in options from a file
        services.AddTransient<ISecretService, SecretService>();
        services.AddSingleton<ISubRedditRepo>(_ => SubRedditRepo.GetRepo(options.SubRedditToWatch));//refactor to change to a DB storage solution include change of scope
        services.AddTransient<IOutputService, OutputService>();
        services.AddTransient<IRedditWrapper, RedditWrapper>();
    }
}