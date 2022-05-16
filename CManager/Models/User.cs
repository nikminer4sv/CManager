using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CManager.Models;

public class User : IdentityUser
{
    public string? FirstName { get; init; }
    public string? LastName { get; set; }
    public string? NickName { get; set; }
    public string? Password { get; set; }
    
    [DataType(DataType.Date)] 
    public DateTime RegisterDate { get; set; }

    [DataType(DataType.Date)] 
    public DateTime LastLoginDate { get; set; }
    
    public string? Role { get; set; }
    public string? Status { get; set; }
}
