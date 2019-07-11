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

namespace GIns.Server.Controllers.Policy
{
    public class PolicyDataAccess : IPolicyRepository
    {
        public ICollection<Policies> oPolicies { get; set; }
        private HttpClient _client;

        private readonly string conn = "Data Source=" + ClsGlobal.SqlSource2 + "; Initial Catalog=" + ClsGlobal.SqlCatalog + "; Persist Security Info=True;" +
                          "User ID=" + ClsGlobal.SqlUser + ";Password=" + ClsGlobal.SqlPassword + "";


        //private readonly string conn2 = "Data Source =(localdb)\MSSQLLocalDB;Initial Catalog = GuardianLifeDB; Integrated Security=True;User ID = sa;Password=dedan!0987o;";

        public PolicyDataAccess()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<Policies>> GetPoliciesAsync(int apiType)
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

                Parm parm = new Parm { DocumentID = -1, Mode = apiType, Policy_id = 0};
                //Execute Storeprocedure for all Points

                oPolicies = Sqlconn.Query<Policies>("PolicyData", parm); //Parameters.Empty);//,

            }


            return oPolicies;
        }

    }
}



//internal class Parm
//{
//    public int DocumentID { get; set; }
//    public int Mode { get; set; }
//    public int Policy_id { get; set; }
//}