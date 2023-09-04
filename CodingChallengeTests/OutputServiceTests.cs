using CodingChallenge.Services;
using FluentAssertions;

namespace CodingChallengeTests;

[TestFixture]
public class OutputServiceTests
{
    [Test]
    public void CanBuildInstanceTest()
    {
        OutputService sut = new OutputService();
        sut.Should().NotBeNull("We should be able to create and instance");
    }

    [Test]
    public void CanSendOutTest()
    {
        OutputService sut = new OutputService();
        sut.SendOut("A test value");
        Assert.IsTrue(true);//the above should not throw
    }
}