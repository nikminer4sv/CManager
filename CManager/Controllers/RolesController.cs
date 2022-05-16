using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace CManager.Controllers;


public class RolesController : Controller
{
    RoleManager<IdentityRole> _roleManager;
    UserManager<User> _userManager;
    public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    [HttpGet]
    [Route("/role/{name:alpha}")]
    public async Task<IActionResult> Create(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }
        return View(name);
    }

    [Route("initroles")]
    public async Task<IActionResult> InitRoles()
    {
        IdentityRole adminRole = new IdentityRole("admin");
        IdentityRole userRole = new IdentityRole("user");
        await _roleManager.CreateAsync(adminRole);
        await _roleManager.CreateAsync(userRole);
        return Content("Roles added");
    }

}
