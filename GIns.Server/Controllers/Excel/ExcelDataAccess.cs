using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GIns.Shared;
using Insight.Database;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace GIns.Server.Controllers.Excel
{
    public class ExcelDataAccess : IExcelRepository
    {
        public ICollection<GInsExcelMap> oGInsExcelMap { get; set; }
        private HttpClient _client;

        private readonly string conn = "Data Source=" + ClsGlobal.SqlSource2 + "; Initial Catalog=" + ClsGlobal.SqlCatalog + "; Persist Security Info=True;" +
                  "User ID=" + ClsGlobal.SqlUser + ";Password=" + ClsGlobal.SqlPassword + "";

        public ExcelDataAccess()
        {
            _client = new HttpClient();
        }


        //private readonly IWebHostEnvironment _hostingEnvironment;

        //public ExcelController(IWebHostEnvironment hostingEnvironment)
        //{
        //    this._hostingEnvironment = hostingEnvironment;
        //}

        public async Task<List<GInsExcelMap>> ImportExcelAsync(IFormFile formFile)
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
                            Firstname = worksheet.Cells[row, 7].Value.ToString(),
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
