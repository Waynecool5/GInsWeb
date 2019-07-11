using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GIns.Shared;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GIns.Server.Controllers.Policy
{
    [Route("api/[controller]")]
    public class PolicyController : Controller
    {
        private IPolicyRepository _PolicyRepository;


        public PolicyController(IPolicyRepository PolicyRepository)
        {
            _PolicyRepository = PolicyRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("GetPoliciesAsync")]
                public async Task<IEnumerable<Policies>> GetPoliciesAsync(int apiType)
        {
            return await _PolicyRepository.GetPoliciesAsync(apiType);
        }
                        
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
