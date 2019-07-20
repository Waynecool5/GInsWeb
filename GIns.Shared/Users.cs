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

    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string APIData { get; set; }
        public string APIKey { get; set; }
        public string APPId { get; set; }
        public string APITimeStamp { get; set; }
    }
}
