using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Configuration;
using System.Reflection.Metadata;
using FluentValidation;
using FluentValidation.Results;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace TermProject.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        protected UserManager<AppUser> userManager { get; }

        PostManager pm = new PostManager(new PostRepository());
        AppDbContext context = new AppDbContext();

        private readonly IEmotionAnalysisService _emotionAnalysisService;

        public PostController(IEmotionAnalysisService emotionAnalysisService)
        {
            _emotionAnalysisService = emotionAnalysisService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PostAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostAdd(Post p)
        {
            PostValidator pv = new PostValidator();
            ValidationResult results = pv.Validate(p);

            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userID = context.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();

            if (results.IsValid)
            {
                p.WriterId = userID;
                // Duygu-durum analizi sonucunu al
                var emotionResult = await _emotionAnalysisService.AnalyzeEmotion(p.Text);
                var newEmotionResult = new EmotionResult { Prediction = emotionResult, UserText = p.Text };
                context.EmotionResults.Add(newEmotionResult);
                context.SaveChanges();
                p.EmotionResultId = newEmotionResult.Id;
                pm.TAdd(p);
                TempData["EmotionResult"] = "Post'unuzun Duygu Durumu: "+ emotionResult;
                TempData["SuccessMessage"] = "Post başarıyla paylaşıldı!";
                return RedirectToAction("PostAdd", "Post");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public async Task<IActionResult> PostEmotionAnalyze()
        {
            var analyzeResults = await pm.GetEmotionSummary();
            return View(analyzeResults);
        }
    }
}
