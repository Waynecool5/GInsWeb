using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GIns.Shared;
using Microsoft.AspNetCore.Http;

namespace GIns.Server.Controllers.Excel
{
    public interface IExcelRepository
    {
        Task<List<GInsExcelMap>> ImportExcelAsync(IFormFile formFile);

    }
}
