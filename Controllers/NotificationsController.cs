using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc.RoleAuthorization.Data;
using PolyFix.Models;

namespace PolyFix.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<PolyFixAppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public NotificationsController(ApplicationDbContext context, UserManager<PolyFixAppUser> userManager,
                RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            var CurUid = _userManager.GetUserId(User);

            var MyNotifications = await _context.Notifications.Where(t => t.ToUserId == CurUid).ToListAsync();

            return View(MyNotifications);
        }

        public async Task<IActionResult> NotiRedirect(string sUrl)
        {
            //return LocalRedirect("/Project/TskIndex/3");
            return LocalRedirect(sUrl);
        }

    }
}
