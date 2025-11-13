using Filminurk.ApplicationServices.Services;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Filminurk.Models.UserComments;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk.Controllers
{
    public class UserCommentsController : Controller
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IUserCommentsServices _userCommentsServices;
        public UserCommentsController(FilminurkTARpe24Context context, IUserCommentsServices userCommentsServies)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.UserComments.Select(c => new UserCommentsIndexViewModel
            {
                CommentID = c.CommentID,
                CommentBody = c.CommentBody,
                IsHarmful = c.IsHarmful,
                CommentCreatedAt = c.CommentCreatedAt,

            });
            return View(result);
        }
        [HttpGet]
        public IActionResult NewComment()
        {
            //TODO:
            UserCommentsCreateViewModel newcomment = new();
            return View(newcomment);
        }
        [HttpPost,ActionName("NewComment")]
        public async Task<IActionResult> NewCommentPost(UserCommentsCreateViewModel newcommentVM)
        {
            var dto = new UserCommentDTO()
            {
                CommentID = (Guid)newcommentVM.CommentID,
                CommentBody = newcommentVM.CommentBody,
                CommenterUserID = newcommentVM.CommenterUserID,
                CommentedScore = newcommentVM.CommentedScore,
                CommentCreatedAt = newcommentVM.CommentCreatedAt,
                CommentModifiedAt = newcommentVM.CommentModifiedAt,
                IsHelpful = (int)newcommentVM.IsHelpful,
                IsHarmful = (int)newcommentVM.IsHarmful,
                
            };
            var result = await _userCommentsServices.NewComment(dto);
            if(result == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> DetailsAdmin(Guid id)
        {
            var requestedComment = await
        }
    }
}
