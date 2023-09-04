namespace CodingChallenge.Data.Model.DB_DTOs;

public class Post
{
    public Post(string title, string author, int upVoteCount)
    {
        Title = title;
        Author = author;
        UpVoteCount = upVoteCount;
    }

    public string Title { get; set; }
    public string Author { get; set; }
    public int UpVoteCount { get; set; }
}