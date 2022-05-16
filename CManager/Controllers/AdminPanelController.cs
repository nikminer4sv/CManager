using CManager.Models;
using Dropbox.Api.TeamCommon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CManager.Controllers;

public class AdminPanelController : Controller
{

    private UserManager<User> _userManager;
    private RoleManager<IdentityRole> _roleManager;
    private ApplicationDbContext _context;

    public AdminPanelController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }
    
    [Authorize(Roles = "admin")]
    public IActionResult AdminPanel()
    {
        return View(_userManager.Users);
    }

    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(string[] ids)
    {
        foreach (var id in ids)
        {
            User userToDelete = _userManager.Users.SingleOrDefault(u => u.Id == id);
            var collections = _context.Collections.Where(c => c.AuthorId == userToDelete.Id);
            _context.RemoveRange(collections);
            _context.SaveChanges();
            //await _userManager.RemoveFromRolesAsync(userToDelete, new string[]{"user", "admin"});
            await _userManager.DeleteAsync(userToDelete);
        }

        User currentUser = _userManager.Users.SingleOrDefault(u => u.Email == User.Identity.Name);


        return await Task.Run(() => RedirectToAction("AdminPanel", "AdminPanel"));
    }

    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Block(string[] ids)
    {

        foreach (var id in ids)
        {
            var userToBlock = _userManager.Users.Single(u => u.Id == id);
            userToBlock.Status = "Blocked";
            await _userManager.UpdateAsync(userToBlock);
        }

        return await Task.Run(() => RedirectToAction("AdminPanel", "AdminPanel"));
    }

    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Unblock(string[] ids)
    {
        foreach (var id in ids)
        {
            var userToUnlock = _userManager.Users.Single(u => u.Id == id);
            userToUnlock.Status = "Active";
            await _userManager.UpdateAsync(userToUnlock);
        }

        return await Task.Run(() => RedirectToAction("AdminPanel", "AdminPanel"));
    }
}