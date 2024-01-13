using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EntityLayer.Model;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;

namespace BusinessLayer.Concrete
{
    public class EmotionAnalysisService : IEmotionAnalysisService
    {
        private readonly HttpClient _httpClient;
        private readonly AppDbContext _context;

        public EmotionAnalysisService(HttpClient httpClient, AppDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }

        public async Task<string> AnalyzeEmotion(string userText)
        {
            try
            {
                // Flask API'ye HTTP POST isteği gönder
                var postData = new { user_text = userText };
                var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("http://127.0.0.1:5000/sentiment", content);

                // Yanıtı al ve içeriği oku
                if (response.IsSuccessStatusCode)
                {
                    var resultJson = await response.Content.ReadAsStringAsync();

                    // JSON verisini EmotionResult sınıfına dönüştür
                    var emotionResult = JsonConvert.DeserializeObject<EmotionResult>(resultJson);

                    // Duygu durumu sonucunu sadece prediction kısmını al
                    var prediction = emotionResult?.Prediction ?? "Unknown";

                    return prediction;
                }
                else
                {
                    // Hata durumunda uygun bir işlem yap
                    return "Unknown";
                }
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine("JSON Deserialize Hatası: " + ex.Message);
                return "Unknown";
            }
        }

        public async Task<EmotionResult> GetEmotionResultByIdAsync(string emotionResultId)
        {
            // Asenkron olarak EmotionResult'ı ID'ye göre getir
            return await _context.EmotionResults.FindAsync(emotionResultId);
        }
    }

}
