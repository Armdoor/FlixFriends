namespace FlixFriends.Models;

public class Like
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int MovieId { get; set; }
    public MovieDetails Media { get; set; }
    public int ShowId { get; set; }
    public ShowDetails Show { get; set; }
}