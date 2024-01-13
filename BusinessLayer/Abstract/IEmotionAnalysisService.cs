using EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEmotionAnalysisService
    {
        Task<string> AnalyzeEmotion(string userText);
        Task<EmotionResult> GetEmotionResultByIdAsync(string emotionResultId);
    }
}
