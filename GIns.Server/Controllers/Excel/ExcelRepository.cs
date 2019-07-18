using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GIns.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GIns.Server.Controllers.Excel
{
    public interface IExcelRepository
    {
        Task<ICollection<GInsExcelMap>> ImportExcelAsync(IFormFile formFile);
        Task<AppList> GetListAsync();
    }
}
