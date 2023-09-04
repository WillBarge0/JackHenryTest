namespace CodingChallenge.Services;

public interface IOutputService
{
    /// <summary>
    /// Sends a value to the user.
    /// </summary>
    /// <param name="valueToBeSent">The value to be sent.</param>
    void SendOut(string valueToBeSent);
}