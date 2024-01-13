using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class PostManager : IPostService
    {
        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public async Task<List<Post>> GetList()
        {
            return await _postDal.GetListAll();
        }

        public async Task<Post> GetPostById(int id)
        {
            var posts = await _postDal.GetListAll(x => x.Id == id);
            return posts.FirstOrDefault();
        }

        public async Task<List<Post>> GetPostListByEmotion()
        {
            return await _postDal.GetPostListByEmotion(); // Bu sadece örnek ama async metodu senkron çağırmak pek iyi bir uygulama pratiği değildir.
        }

        public async Task<List<Post>> GetPostListByAge()
        {
            return await _postDal.GetPostAgeListAsync();
        }

        public async Task<List<Post>> GetPostListByCity()
        {
            return await _postDal.GetPostCityListAsync();
        }

        public async Task<List<Post>> GetPostListByGender()
        {
            return await _postDal.GetPostGenderListAsync();
        }

        public async Task<List<EmotionSummary>> GetEmotionSummary()
        {
            return await _postDal.GetEmotionSummary();
        }

        public async Task<List<Post>> GetPostListByUser(string id)
        {
            var posts = await _postDal.GetPostUserListAsync(id); // Asenkron olarak beklet
            return posts.AsQueryable().Include(p => p.EmotionResult).ToList();
        }

        public void TAdd(Post t)
        {
            _postDal.Insert(t);
        }

        public void TDelete(Post t)
        {
            _postDal.Delete(t);
        }

        public async Task<Post> TGetById(int id)
        {
            return await _postDal.GetById(id);
        }

        public void TUpdate(Post t)
        {
            _postDal.Update(t);
        }

        
    }
}
