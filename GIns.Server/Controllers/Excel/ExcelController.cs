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
        public ICollection<GInsExcelMap> oGInsExcelMap { get; set; }

        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly string conn = "Data Source=" + ClsGlobal.SqlSource2 + "; Initial Catalog=" + ClsGlobal.SqlCatalog + "; Persist Security Info=True;" +
                       "User ID=" + ClsGlobal.SqlUser + ";Password=" + ClsGlobal.SqlPassword + "";

        public ExcelController(IWebHostEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }


        //// POST api/epplus/export
        //[HttpGet("exportv2")]
        //public async Task<IActionResult> ExportV2(CancellationToken cancellationToken)
        //{
        //    // query data from database
        //    await Task.Yield();
        //    var list = new List<GInsExcelMap>()
        //    {
        //        new GInsExcelMap { UserName = "catcher", Age = 18 },
        //        new GInsExcelMap { UserName = "james", Age = 20 },
        //    };
        //    var stream = new MemoryStream();

        //    using (var package = new ExcelPackage(stream))
        //    {
        //        var workSheet = package.Workbook.Worksheets.Add("Sheet1");

        //        // simple way
        //        workSheet.Cells.LoadFromCollection(list, true);

        //        //// mutual
        //        //workSheet.Row(1).Height = 20;
        //        //workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //        //workSheet.Row(1).Style.Font.Bold = true;
        //        //workSheet.Cells[1, 1].Value = "No";
        //        //workSheet.Cells[1, 2].Value = "Name";
        //        //workSheet.Cells[1, 3].Value = "Age";

        //        //int recordIndex = 2;
        //        //foreach (var item in list)
        //        //{
        //        //    workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
        //        //    workSheet.Cells[recordIndex, 2].Value = item.UserName;
        //        //    workSheet.Cells[recordIndex, 3].Value = item.Age;
        //        //    recordIndex++;
        //        //}

        //        package.Save();
        //    }
        //    stream.Position = 0;
        //    string excelName = $"UserList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

        //    return File(stream, "application/octet-stream", excelName);
        //    //return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        //}


        // POST api/epplus/import
        [HttpPost("import")]
        public async Task<List<GInsExcelMap>> Import(IFormFile formFile)
        {
            if (formFile == null || formFile.Length <= 0)
            {
                return null; // GInsExcelMap.GetResult();
            }

            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return null; //GInsExcelMap.GetResult();
            }

            var list = new List<GInsExcelMap>();

            using (var stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        list.Add(new GInsExcelMap
                        {
                            ID = row - 1,
                            PayorID = worksheet.Cells[row, 1].Value.ToString().ToString(),
                            CompanyName = worksheet.Cells[row, 2].Value.ToString(),
                            BenefitContractID = worksheet.Cells[row, 3].Value.ToString(),
                            BenefitContractName = worksheet.Cells[row, 4].Value.ToString(),
                            MemberID = worksheet.Cells[row, 5].Value.ToString(),
                            LastName = worksheet.Cells[row, 6].Value.ToString(),
                            Firstname = worksheet.Cells[row,7].Value.ToString(),
                            Relationship = worksheet.Cells[row, 8].Value.ToString(),
                            DOB = worksheet.Cells[row, 9].Value.ToString(),
                            Gender = worksheet.Cells[row, 10].Value.ToString(),
                            Address1 = worksheet.Cells[row, 11].Value.ToString(),
                            Address2 = worksheet.Cells[row, 12].Value.ToString(),
                            City = worksheet.Cells[row, 13].Value.ToString(),
                            Country = worksheet.Cells[row, 14].Value.ToString(),
                            Phone = worksheet.Cells[row, 15].Value.ToString(),
                            EXT = worksheet.Cells[row, 16].Value.ToString(),
                            Phone2 = worksheet.Cells[row, 17].Value.ToString()
                        });
                    }
                }

                if (list.Count > 0)
                {

                    using (var Sqlconn = new SqlConnection(conn))
                    {
                        await Sqlconn.OpenAsync();

                        Sqlconn.BulkCopy("ExcelImport", list,
                        configure: (InsightBulkCopy bulk) =>
                        {
                            bulk.BatchSize = 50;

                        // InsightBulkCopy wraps the provider-specific BulkCopy object
                        // you can get the provider object by:
                        var sqlBulk = (SqlBulkCopy)bulk.InnerBulkCopy;
                        });
                    }

                    ////Insert to SQL ExcelClients Table


                    //// add list to db ..
                    //// here just read and return
                    ////GInsExcelMap oGInsExcelMap = list;

                    ////return oGInsExcelMap;


                }

                return list;
            }


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

