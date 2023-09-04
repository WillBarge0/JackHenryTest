using CodingChallenge.Data.Model.DB_DTOs;

namespace CodingChallenge.Data.Repos;

public interface ISubRedditRepo
{
    void SetPost(Post postToUpdate);
    void RemoveAllPost();
    IEnumerable<Post> GetAllPosts();
    IEnumerable<Post> GetPostsWithMostUpVotes(int numberOfTopResults);
    IEnumerable<string> GetUsersWithMostPosts(int numberOfTopResults);

}