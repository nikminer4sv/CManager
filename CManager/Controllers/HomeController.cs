using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CManager.Models;
using CManager.ViewModels;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CManager.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<User> _userManager;
    private ApplicationDbContext _context;
    
    public HomeController(ILogger<HomeController> logger, UserManager<User> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    [Authorize]
    public IActionResult Profile()
    {
        User? user = _userManager.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
        return View(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> Search(string searchString)
    {

        SearchViewModel searchViewModel = new()
        {
            resultItems = FullTextSearch(searchString),
            Text = searchString
        };

        return await Task.Run(() => View("Search", searchViewModel));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }

    List<Item> FullTextSearch(string searchString)
    {   
        var resultItems = new List<Item>();
        foreach (var item in _context.Items.FullTextSearchQuery(searchString).ToList())
            resultItems.Add(item);
        
        return resultItems;
    }

    [Route("Home/GetAmountOfLikes/{itemId:int}")]
    public int GetAmountOfLikes(int itemId)
    {
        return _context.Likes.Where(l => l.ItemId == itemId).Count();
    }

    [HttpPost]
    [Route("/Home/{itemId::int}/SwitchLike")]
    public async Task<IActionResult> SwitchLike(int itemId)
    {

        string userId = (await _userManager.Users.SingleAsync(u => u.Email == User.Identity.Name)).Id;
        
        if (_context.Likes.SingleOrDefaultAsync(l => l.ItemId == itemId && l.UserId == userId).Result == null)
        {
            Like like = new Like()
            {
                UserId = userId,
                ItemId = itemId
            };
            
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }
        else
        {
            Like like = await _context.Likes.SingleAsync(l => l.ItemId == itemId && l.UserId == userId);
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
        }

        return await Task.Run(NoContent);
    }
    
}