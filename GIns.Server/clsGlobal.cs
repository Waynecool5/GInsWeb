using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIns.Server
{
    public class ClsGlobal
    {
        public const Int32 BUFFER_SIZE = 10; // Unmodifiable
        public static String FILE_NAME = "Output.txt"; // Modifiable
        public static readonly String CODE_PREFIX = "US-"; // Unmodifiable
        public static String Encoding_KB = "8080808080808080"; // Unmodifiable
        public static String Encoding_IV = "8080808080808080"; // Unmodifiable


        ////Live Test
        //public static String SqlUser = "DB_A428B0_WebAsync_admin"; // Modifiable
        //public static String SqlPassword = "dedan!0987o"; // Modifiable
        //public static String SqlCatalog = "DB_A428B0_WebAsync";
        //public static String SqlSource2 = "SQL5030.site4now.net"; //office\\sql2017"; // "(LOCALDB)\\MSSQLLOCALDB";

        //Local Testing
        public static String SqlUser = "sa"; // Modifiable
        public static String SqlPassword = "dedan!0987o"; // Modifiable
        public static String SqlCatalog = "GuardianLifeDB"; //"WebAsync";
        public static String SqlSource2 = "(LOCALDB)\\MSSQLLOCALDB"; //"LAPTOPHP\\SQLEXP2017"; //office\\sql2017"; // "(LOCALDB)\\MSSQLLOCALDB";
       // public static String SqlSource2 = "OFFICE\\SQL2017"; //office\\sql2017"; // "(LOCALDB)\\MSSQLLOCALDB";


        public static String MassyAPIver134 = "http://beta.massycard.com/loyalty/massy/api/rest2/";
        public static readonly string Secret = "weg24*792#9Fe8PO87u56f122@b=ksJ3ou80";
        //Install-Package System.Data.Common -Version 4.3.0
        //Install-Package System.Data.SqlClient -Version 4.5.1
        //Install-Package Newtonsoft.Json -Version 11.0.2
        //Install-Package EPPlus -Version 4.5.2.1
    }
}
