using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodingChallenge
{
    internal class Program
    {
        private const string REFRESH_TOKEN = @"52349536581675-x4gJvhb8ND469zMfmR9HnaaEw5qxSA";

        private const string APP_ID = "oZupYoXzQ9VOCuq0NcWlNw";

        private const string SUB_REDDIT_NAME = "ProgrammerHumor";

        private const int NUMBER_OF_RESULTS_TO_DISPLAY = 5;

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