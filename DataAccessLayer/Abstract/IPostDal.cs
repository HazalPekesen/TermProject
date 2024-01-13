using EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPostDal : IGenericDal<Post>
    {
        Task<List<Post>> GetPostUserListAsync(string id);
        Task<List<Post>> GetPostGenderListAsync();
        Task<List<Post>> GetPostCityListAsync();
        Task<List<Post>> GetPostAgeListAsync();
        Task<List<Post>> GetPostListByEmotion();
        Task<List<EmotionSummary>> GetEmotionSummary();
    }
}
