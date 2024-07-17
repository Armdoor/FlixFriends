namespace FlixFriends.Models;

public class Reply
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public int ReviewId { get; set; }
    public Review Review { get; set; }
    public string Content { get; set; }
    public DateTime ReplyDate { get; set; }
}