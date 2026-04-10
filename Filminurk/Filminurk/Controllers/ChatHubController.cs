using Filminurk.Core.Domain;
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

    }
}
