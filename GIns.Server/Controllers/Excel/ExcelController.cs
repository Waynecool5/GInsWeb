using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using GIns.Shared;
using Microsoft.AspNetCore.Http;
using System.Threading;
using Newtonsoft.Json;
using Insight.Database;
using System.Data.SqlClient;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GIns.Server.Controllers.Excel
{
    [Route("api/[controller]")]
    public class ExcelController : Controller
    {

        private IExcelRepository _ExcelRepository;


        public ExcelController(IExcelRepository ExcelRepository)
        {
            _ExcelRepository = ExcelRepository;
        }


    
        // POST api/epplus/import
       // [HttpPost("import")]
        [HttpPost]
        [Route("ImportExcelAsync")]
        public async Task<GInsExcelMap> ImportExcelAsync(IFormFile formFile)
        {
            return await _ExcelRepository.ImportExcelAsync(formFile);
        }


    }
}
        //// POST api/epplus/export
        //[HttpGet("export")]
        //public async Task<DemoResponse<string>> Export(CancellationToken cancellationToken)
        //{
        //    string folder = _hostingEnvironment.WebRootPath;
        //    string excelName = $"UserList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
        //    string downloadUrl = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, excelName);
        //    FileInfo file = new FileInfo(Path.Combine(folder, excelName));
        //    if (file.Exists)
        //    {
        //        file.Delete();
        //        file = new FileInfo(Path.Combine(folder, excelName));
        //    }

        //    // query data from database
        //    await Task.Yield();

        //    var list = new List<UserInfo>()
        //    {
        //        new UserInfo { UserName = "catcher", Age = 18 },
        //        new UserInfo { UserName = "james", Age = 20 },
        //    };

        //    using (var package = new ExcelPackage(file))
        //    {
        //        var workSheet = package.Workbook.Worksheets.Add("Sheet1");

        //        workSheet.Cells.LoadFromCollection(list, true);

        //        package.Save();
        //    }

        //    return DemoResponse<string>.GetResult(0, "OK", downloadUrl);
        //}
//    }
//}

