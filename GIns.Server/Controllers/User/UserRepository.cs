using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GIns.Shared;

namespace GIns.Server.Controllers.User
{
    public interface IUserRepository
    {
        //object Authenticate(string loginName, string loginPwd, string userLevel);
        Task<IEnumerable<Users>> GetUsersAsync(int apiType);
        Task<IEnumerable<Users>> GetAll();
        
    }
}
