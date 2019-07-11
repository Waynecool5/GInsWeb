using System;
using System.Collections.Generic;
using System.Text;

namespace GIns.Shared
{
    public class GInsExcelMap
    {
        public int ID { get; set; }
        public string PayorID { get; set; }
        public string CompanyName { get; set; }
        public string BenefitContractID { get; set; }
        public string BenefitContractName { get; set; }
        public string MemberID { get; set; }
        public string LastName { get; set; }
        public string Firstname { get; set; }
        public string Relationship { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string EXT { get; set; }
        public string Phone2 { get; set; }

        public static GInsExcelMap GetResult()
        {
            return new GInsExcelMap
            {
                ID = -1,
                PayorID = "",
                CompanyName = "",
                BenefitContractID = "",
                BenefitContractName = "",
                MemberID = "",
                LastName = "",
                Firstname = "",
                Relationship = "",
                DOB = "",
                Gender = "",
                Address1 = "",
                Address2 = "",
                City = "",
                Country = "",
                Phone = "",
                EXT = "",
                Phone2 = ""
            };
        }
    }

}
