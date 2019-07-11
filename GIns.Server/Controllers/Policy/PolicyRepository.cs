using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GIns.Shared;

namespace GIns.Server.Controllers.Policy
    {
    public interface IPolicyRepository
    {
        Task<IEnumerable<Policies>> GetPoliciesAsync(int apiType);
        
    }
}
