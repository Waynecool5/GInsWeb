using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GIns.Shared;

namespace GIns.Server.Controllers.User
{
    public interface IUserRepository
    {
        UserModel Authenticate(string username, string password, string appid, string apidata, string apiTime);

        IEnumerable<UserModel> GetAll();

    }
}

//public interface IUserService
//{
//    Users Authenticate(string username, string password);
//    IEnumerable<Users> GetAll();
//}