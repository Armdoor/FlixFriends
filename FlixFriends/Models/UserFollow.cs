namespace FlixFriends.Models;

public class UserFollow
{
    public int Id { get; set; }
    public string FollowerId { get; set; }
    public User Follower { get; set; }
    public string FollowedId { get; set; }
    public User Followed { get; set; }
}