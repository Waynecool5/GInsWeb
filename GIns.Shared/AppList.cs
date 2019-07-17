using System;
using System.Collections.Generic;
using System.Text;

namespace GIns.Shared
{

    public class AppList
    {
        public IEnumerable<PayorList> PList { get; set; }
        public IEnumerable<CompNameList> CmpNameList { get; set; }
        public IEnumerable<BenefitContList> BenefContList { get; set; }
        public IEnumerable<BenefitNameList> BenefNameList { get; set; }
        public IEnumerable<ClientList> CliList { get; set; }
    }
  

    public class PayorList
    {
        public int ID { get; set; }
        public string PayorID { get; set; }
    }


    public class CompNameList
    {
        public int ID { get; set; }
        public string CompName { get; set; }
    }


    public class BenefitContList
    {
        public int ID { get; set; }
        public string BfContractID { get; set; }
    }


    public class BenefitNameList
    {
        public int ID { get; set; }
        public string BfName { get; set; }
    }


    public class ClientList
    {
        public int Cus_ID { get; set; }
        public string MemberID { get; set; }
        public string First_Name { get; set; }
        public string Mid_Init { get; set; }
        public string Last_Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public object Mobile { get; set; }
        public object Mobile2 { get; set; }
        public object Email { get; set; }
        public object Email2 { get; set; }
        public string Related { get; set; }
        public object NIS { get; set; }
        public object PAYE { get; set; }
        public object DLN { get; set; }
        public object SSN { get; set; }
        public object PPN { get; set; }
        public object Billing_Address { get; set; }
        public object Billing_Country { get; set; }
        public object Billing_Phone { get; set; }
        public object Billing_Email { get; set; }
        public object RegDate { get; set; }
        public string ClientSrch { get; set; }
    }


}
