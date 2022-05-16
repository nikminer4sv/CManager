using CManager.Models;
using CManager.Models;

namespace CManager.ViewModels;

public class SearchViewModel
{
    public List<Item> resultItems { get; set; }
    public string? Text { get; set; }
}