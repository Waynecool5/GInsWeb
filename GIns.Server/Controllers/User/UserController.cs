using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GIns.Shared;


//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GIns.Server.Controllers.User
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserRepository _UserRepository;


        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("GetUsersAsync")]
        public async Task<IEnumerable<Users>> GetUsersAsync(int apiType)
        {
            return await _UserRepository.GetUsersAsync(apiType);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Users>> GetAll()
        {
            return await _UserRepository.GetAll();
        }
    }
}
//        // GET api/<controller>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<controller>
//        [HttpPost]
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT api/<controller>/5
//        [HttpPut("{id}")]
//        public void Put(int ID, [FromBody]string value)
//        {
//        }

//        // DELETE api/<controller>/5
//        [HttpDelete("{id}")]
//        public void Delete(int ID)
//        {
//        }
//    }
//}
