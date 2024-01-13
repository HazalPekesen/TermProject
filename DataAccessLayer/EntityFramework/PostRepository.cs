using DataAccessLayer.Abstract;
using EntityLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class PostRepository : GenericRepository<Post>, IPostDal
    {

        public async Task<List<Post>> GetPostUserListAsync(string id)
        {
            using (var c = new AppDbContext())
            {
                return await c.Posts.Include(x => x.Writer).OrderByDescending(x => x.Id).Where(x => x.WriterId == id).ToListAsync();
            }

        }
        public async Task<List<Post>> GetPostAgeListAsync()
        {
            using (var c = new AppDbContext())
            {
                return await c.Posts.Include(x => x.Writer.BirthDate).ToListAsync();
            }

        }

        public async Task<List<Post>> GetPostCityListAsync()
        {
            using (var c = new AppDbContext())
            {
                return await c.Posts.Include(x => x.Writer.City).ToListAsync();
            }

        }

        public async Task<List<Post>> GetPostGenderListAsync()
        {
            using (var c = new AppDbContext())
            {
                return await c.Posts.Include(x => x.Writer.Gender).ToListAsync();
            }
        }

        public async Task<List<Post>> GetPostListByEmotion()
        {
            using (var context = new AppDbContext())
            {
                return await context.Posts
                    .Include(p => p.EmotionResult) // EmotionResult'ı include et
                    .Select(p => new Post // Post nesnesini seç ve dönüştür
                    {
                        Id = p.Id,
                        Text = p.Text,
                        Writer = p.Writer,
                        WriterId = p.WriterId,
                        EmotionResultId = p.EmotionResultId,
                        EmotionResult = new EmotionResult // Yeni EmotionResult nesnesi oluştur
                        {
                            Id = p.EmotionResult.Id,
                            Prediction = p.EmotionResult.Prediction,
                            UserText = p.EmotionResult.UserText
                            // Diğer EmotionResult özelliklerini ekleyebilirsiniz
                        }
                    })
                    .ToListAsync();
            }
        }

        public async Task<List<EmotionSummary>> GetEmotionSummary()
        {
            using (var context = new AppDbContext())
            {
                var emotionSummary = await context.Posts
                    .GroupBy(p => p.EmotionResult.Prediction)
                    .Select(g => new EmotionSummary
                    {
                        Emotion = g.Key,
                        PostCount = g.Count()
                    })
                    .ToListAsync();

                return emotionSummary;
            }
        }
    }
}
