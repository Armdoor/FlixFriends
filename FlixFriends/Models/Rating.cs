namespace FlixFriends.Models;

public class Rating
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public int MovieId { get; set; }
    public MovieDetails Movie { get; set; }
    public int Score { get; set; }
}