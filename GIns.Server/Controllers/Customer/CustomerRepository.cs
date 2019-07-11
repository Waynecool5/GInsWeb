using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GIns.Shared;

namespace GIns.Server.Controllers.Customer
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customers>> GetCustomersAsync(int apiType);
    }
}
