using System.ComponentModel.DataAnnotations;

namespace CManager.ViewModels;

public class ItemViewModel
{
    public int Id { get; set; }
    public int CollectionId { get; set; }
    
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? Brand { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime? Date { get; set; }
}
