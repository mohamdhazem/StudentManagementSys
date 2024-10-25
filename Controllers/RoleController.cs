using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcDay2Task.Migrations;
using MvcDay2Task.Models;

namespace MvcDay2Task.Controllers
{
    public class RoleController : Controller
    {
		private readonly RoleManager<IdentityRole> roleManager;

		public RoleController(RoleManager<IdentityRole> roleManager) 
        {
			this.roleManager = roleManager;
		}
        public IActionResult AddRole()
        {
            return View("AddRole");
        }
        public async Task<IActionResult> SaveRole(RoleData roleData)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = roleData.RoleName;
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return View("AddRole");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("AddRole", roleData);
        }
    }
}