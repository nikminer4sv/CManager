using HigLabo.Core;
using CManager.Models;
using Dropbox.Api.TeamCommon;
using Dropbox.Api.TeamLog;
using Korzh.EasyQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace CManager.Hub;

public class CommentsHub : Microsoft.AspNetCore.SignalR.Hub
{
    private UserManager<User> _userManager;
    private ApplicationDbContext _context;
    
    public CommentsHub(UserManager<User> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    [Authorize]
    public async Task SendComment(string comment, string itemId)
    {
        var user = _userManager.Users.Single(u => u.Email == Context.User.Identity.Name);

        var commentTime = DateTime.UtcNow.AddHours(3).ToString("MM/dd/yyyy H:mm");
        
        var newComment = new Comment
        {
            Content = comment, 
            PostDate= commentTime, 
            NickName = user.NickName, 
            ItemId = itemId.ToInt()
        };

        await _context.Comments.AddAsync(newComment);
        await _context.SaveChangesAsync();
        await Clients.All.SendAsync("ReceiveComment", user.NickName,comment, commentTime);
    }
}