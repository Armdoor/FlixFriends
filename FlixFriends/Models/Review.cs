namespace FlixFriends.Models;

public class Review
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public int MovieId { get; set; }
    public MovieDetails Movie { get; set; }
    public string Content { get; set; }
    public DateTime ReviewDate { get; set; }
    public ICollection<Reply> Replies { get; set; }
    public ICollection<Like> Likes { get; set; }
}