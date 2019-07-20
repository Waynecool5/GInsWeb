using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GIns.Shared;
using Microsoft.AspNetCore.Authorization;


//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GIns.Server.Controllers.User
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public UserModel user { get; set; }
        private IUserRepository _UserRepository;

        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        // GET: api/<controller>
        //[AllowAnonymous]
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/<controller>
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody]UserModel userParam)
        {
            user = _UserRepository.Authenticate(userParam.Username, userParam.Password, userParam.APPId, userParam.APIData, userParam.APITimeStamp);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _UserRepository.GetAll();
            return Ok(users);
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
