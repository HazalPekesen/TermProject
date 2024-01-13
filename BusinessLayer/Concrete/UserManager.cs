using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<List<AppUser>> GetList()
        {
            return await _userDal.GetListAll();
        }

        public async Task<List<AppUser>> GetUserListById(string id)
        {
            var users = await _userDal.GetListAll(x => x.Id == id);
            return users;
        }

        public void TAdd(AppUser t)
        {
            _userDal.Insert(t);
        }

        public void TDelete(AppUser t)
        {
            _userDal.Delete(t);
        }

        public async Task<AppUser> TGetById(int id)
        {
            return await _userDal.GetById(id);
        }

        public void TUpdate(AppUser t)
        {
            _userDal.Update(t);
        }
    }
}
