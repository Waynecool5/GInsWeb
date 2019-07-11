using System;
using System.Collections.Generic;
using System.Text;

namespace GIns.Shared
{
    public class Users
    {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string MidInit { get; set; }
            public string LastName { get; set; }
            public string LoginName { get; set; }
            public string LoginPwd { get; set; }
            public string UserLevel { get; set; }
            public bool Access { get; set; }
            public string CompanyName { get; set; }
    }
}
