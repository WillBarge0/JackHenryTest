// ***********************************************************************
// Assembly         : CodingChallenge
// Author           : Bill Barge
// Created          : 09-03-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 09-03-2023
// ***********************************************************************
// <copyright file="Program.cs" company="CodingChallenge">
//     Copyright (c) N/A. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodingChallenge
{
    /// <summary>
    /// Class Program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The refresh token
        /// </summary>
        private const string REFRESH_TOKEN = @"52349536581675-x4gJvhb8ND469zMfmR9HnaaEw5qxSA";

        /// <summary>
        /// The application identifier
        /// </summary>
        private const string APP_ID = "oZupYoXzQ9VOCuq0NcWlNw";

        /// <summary>
        /// The sub reddit name
        /// </summary>
        private const string SUB_REDDIT_NAME = "ProgrammerHumor";

        /// <summary>
        /// The number of results to display
        /// </summary>
        private const int NUMBER_OF_RESULTS_TO_DISPLAY = 5;

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static async Task Main(string[] args)
        {

            CodingChallengeOptions options = new CodingChallengeOptions
            {
                SubRedditToWatch = SUB_REDDIT_NAME,
                AppId = APP_ID,
                RefreshToken = REFRESH_TOKEN,
                ResultSetSize = NUMBER_OF_RESULTS_TO_DISPLAY
            };


            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    CompositionRoot.ConfigureLocalObjects(services,options);
                    services.AddHostedService<DriverService>();
                })
                
                .Build();

            await host.RunAsync();
        }
    }
}