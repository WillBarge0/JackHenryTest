namespace CodingChallenge.Services;

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