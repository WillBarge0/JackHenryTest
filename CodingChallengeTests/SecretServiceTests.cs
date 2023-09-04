using CodingChallenge;
using CodingChallenge.Services;
using FluentAssertions;

namespace CodingChallengeTests;

[TestFixture]
public class SecretServiceTests
{
    private ICodingChallengeOptions options = new CodingChallengeOptions();

    [Test]
    public void OptionsAreRequiredToCreateTest()
    {
        Assert.Throws<ArgumentNullException>(() => new SecretService(null!));
    }

    [Test]
    public void CanBuildInstanceTest()
    {
        SecretService sut = new SecretService(options);
        sut.Should().NotBeNull("We should be able to create and instance");
    }

    [Test]
    public void CanGetRefreshToken()
    {
        ISecretService sut = new SecretService(options);

        Task.Run(async () =>
        {
            string result = await sut.GetRefreshTokenAsync();
            result.Trim().Should().NotBeNullOrEmpty("we want a value to be returned");
        });

    }

    [Test]
    public void CanGetApplicationId()
    {
        ISecretService sut = new SecretService(options);
        Task.Run(async () =>
        {
            string result = await sut.GetAppIdAsync();
            result.Trim().Should().NotBeNullOrEmpty("we want a value to be returned");

        });
    }

}