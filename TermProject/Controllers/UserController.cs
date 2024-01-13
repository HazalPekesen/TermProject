using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer.Model;
using EntityLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace TermProject.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserManager um = new UserManager(new UserRepository());
        PostManager pm = new PostManager(new PostRepository());
        AppDbContext c = new AppDbContext();

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        private readonly IEmotionAnalysisService _emotionAnalysisService;

        public UserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IEmotionAnalysisService emotionAnalysisService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emotionAnalysisService = emotionAnalysisService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                if (currentUser != null)
                {
                    var member = currentUser.Id;
                    // Her bir post için EmotionResult'ı alın
                    var postViewModels = new List<PostViewModel>();
                    var posts = await pm.GetPostListByUser(member);
                    foreach (var post in posts)
                    {
                        var emotionResult = await _emotionAnalysisService.GetEmotionResultByIdAsync(post.EmotionResultId);
                        postViewModels.Add(new PostViewModel { Post = post, EmotionResult = emotionResult });
                    }
                    ViewBag.v1 = currentUser.UserName;
                    ViewBag.v2 = currentUser.Gender;
                    ViewBag.v3 = currentUser.Picture;
                    ViewBag.v4 = currentUser.City;
                    return View(postViewModels);
                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
