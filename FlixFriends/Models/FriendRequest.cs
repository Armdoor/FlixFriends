namespace FlixFriends.Models;

public class FriendRequest
{
    public int Id { get; set; }
    public string SenderId { get; set; }
    public User Sender { get; set; }
    public string ReceiverId { get; set; }
    public User Receiver { get; set; }
    public DateTime RequestDate { get; set; }
    public bool IsAccepted { get; set; }
}