using Bussiness.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void TDelete(AppUser p)
        {
            throw new NotImplementedException();
        }

        public AppUser TGetByID(int id)
        {
           return _userDal.GetByID(id);
        }

        public List<AppUser> TGetList()
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppUser>> TGetUserAsync()
        {
            return await _userDal.GetUserAsync();
        }

        public void TInsert(AppUser p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AppUser p)
        {
            throw new NotImplementedException();
        }
    }
}
