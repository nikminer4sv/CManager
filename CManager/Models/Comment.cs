using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CManager.Models;

public class Comment
{
    public int Id { get; init; }
    
    public string NickName { get; init; }
    public int ItemId { get; init; }
    
    public string Content { get; init; }
    
    public string PostDate { get; init; }
}