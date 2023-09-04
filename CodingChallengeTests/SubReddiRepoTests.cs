using CodingChallenge.Data.Model.DB_DTOs;
using CodingChallenge.Data.Repos;
using FluentAssertions;

namespace CodingChallengeTests;

public class SubReddiRepoTests
{
    [Test]
    public void NameIsRequiredToCreateTest()
    {
        Assert.Throws<ArgumentNullException>(() => SubRedditRepo.GetRepo(null!));
        Assert.Throws<ArgumentNullException>(() => SubRedditRepo.GetRepo(string.Empty));
    }

    [Test]
    public void CanCreateInstance()
    {
        ISubRedditRepo sut = SubRedditRepo.GetRepo(TEST_STRING);
        sut.Should().NotBeNull();
    }

    [Test]
    public void RemoveAllPostsTest()
    {
        ISubRedditRepo sut = SubRedditRepo.GetRepo(TEST_STRING);
        Post testValue = CreateTestPost();
        sut.SetPost(testValue);

        sut.RemoveAllPost();
        IEnumerable<Post> results = sut.GetAllPosts();
        results.Should().HaveCount(0);
    }
    
    [Test]
    public void SetWillAddAPostTest()
    {
        ISubRedditRepo sut = SubRedditRepo.GetRepo(TEST_STRING);
        sut.RemoveAllPost();
        Post testValue = CreateTestPost();
        sut.SetPost(testValue);

        IEnumerable<Post> results = sut.GetAllPosts();
        results.Should().HaveCount(1);
    }

    [Test]
    public void SetWillUpdateAPostTest()
    {
        ISubRedditRepo sut = SubRedditRepo.GetRepo(TEST_STRING);
        sut.RemoveAllPost();
        Post testValue = CreateTestPost();
        sut.SetPost(testValue);
        testValue.UpVoteCount = 1;
        sut.SetPost(testValue);

        IEnumerable<Post> results = sut.GetAllPosts();
        results.Should().HaveCount(1);
#pragma warning disable CS8600
        Post firstResult = results.FirstOrDefault();
#pragma warning restore CS8600
        firstResult.Should().NotBeNull();
#pragma warning disable CS8602
        firstResult.UpVoteCount.Should().Be(1);
#pragma warning restore CS8602

    }

    [Test]
    public void GetPostWithMostUpVotesTest()
    {
        //setup
        ISubRedditRepo sut = SubRedditRepo.GetRepo(TEST_STRING);
        sut.RemoveAllPost();
        Post testValue = CreateTestPost();
        testValue.UpVoteCount = 5;
        sut.SetPost(testValue);
        testValue = CreateTestPost("1");
        testValue.UpVoteCount = 1;
        sut.SetPost(testValue);
        testValue = CreateTestPost("2");
        testValue.UpVoteCount = 2;
        sut.SetPost(testValue);
        testValue = CreateTestPost("3");
        testValue.UpVoteCount = 6;
        sut.SetPost(testValue);

        Post[] result = sut.GetPostsWithMostUpVotes(3).ToArray<Post>();
        result.Should().HaveCount(3);
        result[0].UpVoteCount.Should().Be(6);
        result[1].UpVoteCount.Should().Be(5);
        result[2].UpVoteCount.Should().Be(2);
    }

    [Test]
    public void GetUsersWithMostPost()
    {
        ISubRedditRepo sut = SubRedditRepo.GetRepo(TEST_STRING);
        sut.RemoveAllPost();
        Post testValue = CreateTestPost();
        testValue.UpVoteCount = 5;
        sut.SetPost(testValue);
        testValue = CreateTestPost("1");
        testValue.UpVoteCount = 1;
        sut.SetPost(testValue);
        testValue = CreateTestPost("2","1");
        testValue.UpVoteCount = 2;
        sut.SetPost(testValue);
        testValue = CreateTestPost("3","1");
        testValue.UpVoteCount = 6;
        sut.SetPost(testValue);
        testValue = CreateTestPost("4","2");
        testValue.UpVoteCount = 6;
        sut.SetPost(testValue);
        testValue = CreateTestPost("5");
        testValue.UpVoteCount = 6;
        sut.SetPost(testValue);

        string[] results = sut.GetUsersWithMostPosts(2).ToArray<string>();
        results.Should().HaveCount(2);
        results[0].Should().BeEquivalentTo(TEST_STRING);
        results[1].Should().BeEquivalentTo(TEST_STRING+"1");

    }

    private const string TEST_STRING = "test";
    private const int INIT_UP_VOTE_VALUE = 0;

    private Post CreateTestPost(string titleAddition = "",string authorAddition = "")
    {
        return new Post(TEST_STRING+titleAddition, TEST_STRING+authorAddition, INIT_UP_VOTE_VALUE);
    }

}