using System.Reflection.Metadata.Ecma335;

namespace CodingChallenge;

public interface ICodingChallengeOptions
{
    string SubRedditToWatch { get; set; }
    string AppId { get; set; }
    string RefreshToken { get; set; }
    int ResultSetSize { get; set; }
}

public class CodingChallengeOptions : ICodingChallengeOptions
{
    public string SubRedditToWatch { get; set; } = null!;
    public string AppId { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public int ResultSetSize { get; set; }
}