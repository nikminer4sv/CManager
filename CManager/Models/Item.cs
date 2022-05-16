using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CManager.Models;

public class Item
{
    public int Id { get; set; }
    
    public int CollectionId { get; set; }
    
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? LastEditDate { get; set; }
    
    public string? Brand { get; set; }
    
    public string? FileName { get; set; }
    
    [DataType(DataType.Time)]
    public DateTime? Date { get; set; }
}