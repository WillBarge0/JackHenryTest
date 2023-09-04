using CodingChallenge.Data.Repos;
using CodingChallenge.Reddit;
using CodingChallenge.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodingChallenge;

internal class CompositionRoot
{
    internal static void ConfigureLocalObjects(IServiceCollection services,ICodingChallengeOptions options)
    {
        services.AddSingleton<ICodingChallengeOptions>(options);//refactor to use built-in options from a file
        services.AddTransient<ISecretService, SecretService>();
        services.AddSingleton<ISubRedditRepo>(provider => SubRedditRepo.GetRepo(options.SubRedditToWatch));//refactor to change to a DB storage solution include change of scope
        services.AddTransient<IOutputService, OutputService>();
        services.AddTransient<IRedditWrapper, RedditWrapper>();
    }
}