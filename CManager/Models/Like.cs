using Microsoft.EntityFrameworkCore;

namespace CManager.Models;

public class Like
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int ItemId { get; set; }
}