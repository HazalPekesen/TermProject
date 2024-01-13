using BusinessLayer.Concrete;
using DataAccessLayer;
using EntityLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TermProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmotionAnalysisController : Controller
    {
        private readonly AppDbContext _context;
        private readonly EmotionAnalysisService _emotionAnalysisService;

        public EmotionAnalysisController(EmotionAnalysisService emotionAnalysisService)
        {
            _emotionAnalysisService = emotionAnalysisService;
        }

        [HttpPost]
        public async Task<IActionResult> AnalyzeSentiment([FromBody] string userText)
        {
            var result = await _emotionAnalysisService.AnalyzeEmotion(userText);

            // Burada result değişkenini kullanarak işlemlerinizi gerçekleştirebilirsiniz.
            // Örneğin, result içeriğini işleyip bir model döndürebilirsiniz.

            return Ok(result);
        }
    }
}