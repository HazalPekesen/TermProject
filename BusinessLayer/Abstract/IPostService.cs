using EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPostService : IGenericService<Post>
    {
        Task<Post> GetPostById(int id);
        Task<List<Post>> GetPostListByUser(string id);
        Task<List<Post>> GetPostListByGender();
        Task<List<Post>> GetPostListByCity();
        Task<List<Post>> GetPostListByAge();
        Task<List<Post>> GetPostListByEmotion();
        Task<List<EmotionSummary>> GetEmotionSummary();
    }
}
