using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Insight.Database;
using Insight.Database.Reliable;
using Insight.Database.Providers;
using System.Net.Http;
using GIns.Shared;

namespace GIns.Server.Controllers.Customer
{
    public class CustomerDataAccess : ICustomerRepository
    {
        public ICollection<Customers> oCustomers { get; set; }
        private HttpClient _client;

        private readonly string conn = "Data Source=" + ClsGlobal.SqlSource2 + "; Initial Catalog=" + ClsGlobal.SqlCatalog + "; Persist Security Info=True;" +
                          "User ID=" + ClsGlobal.SqlUser + ";Password=" + ClsGlobal.SqlPassword + "";


        //private readonly string conn2 = "Data Source = OFFICE\\SQL2017;Initial Catalog = WebAsync; Persist Security Info=True;User ID = sa;Password=dedan!0987o;";

        public CustomerDataAccess()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<Customers>> GetCustomersAsync(int apiType)
        {
            // @Mode = 0-- Select 
            //@Mode = 2--Insert 
            //@Mode = 3-- Update
            //@Mode = 4-- Delete
          
            //For Cloud connections like AZure
            //using (var Sqlconn = new ReliableConnection<SqlConnection>(conn)) 

            using (var Sqlconn = new SqlConnection(conn))
            {
                await Sqlconn.OpenAsync();

                Parm parm = new Parm { DocumentID = -1, Mode = apiType, Customer_id = 0};
                //Execute Storeprocedure for all Points

                oCustomers = Sqlconn.Query<Customers>("CustomerData", parm); //Parameters.Empty);//,

            }


            return oCustomers;
        }

    }
}



internal class Parm
{
    internal int User_id;

    public int DocumentID { get; set; }
    public int Mode { get; set; }
    public int Customer_id { get; set; }
    public int Policy_id { get; internal set; }
}