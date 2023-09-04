namespace CodingChallenge.Data.Model.DB_DTOs;

public class Sub
{
    public Sub(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Posts = new List<Post>();
    }
    public string Name { get; set; }
    public ICollection<Post> Posts { get; set; }
}