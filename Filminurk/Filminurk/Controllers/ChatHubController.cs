using Filminurk.Core.Domain;
using Filminurk.Models.ChatHub;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk.Controllers
{
    [Authorize]
    public class ChatHubController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatHubController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Accounts");

            var vm = new ChatHubIndexViewModel
            {
                UserName = user.UserName
            };

            return View(vm);
        }

    }
}
