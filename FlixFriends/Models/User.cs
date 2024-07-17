using Microsoft.AspNetCore.Identity;

namespace FlixFriends.Models;

public class User:IdentityUser
{

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public byte[] Image { get; set; }
    public ICollection<FriendRequest> FriendRequestsSent { get; set; }
    public ICollection<FriendRequest> FriendRequestsReceived { get; set; }
    public ICollection<UserFollow> Following { get; set; }
    public ICollection<UserFollow> Followers { get; set; }
    public ICollection<MovieFollow> MovieFollows { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Reply> Replies { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Watch> WatchList { get; set; }
    public ICollection<Rating> Ratings { get; set; }
}


