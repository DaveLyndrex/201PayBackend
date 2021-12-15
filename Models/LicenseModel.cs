/* 07/10/2021 CN A.Diez */
/* 10/08/2021 CN A.Diez */

namespace BackEnd.Models
{
    public class LicenseModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
        public string Remarks { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string LicenseNo { get; set; }
        public string RenewalDate { get; set; }
        public string Renewed { get; set; }
        public string LegislationCode { get; set; }
        public string LicenseType { get; set; }
        public string IssuingAuthority { get; set; }
        public string IssuingCountry { get; set; }
        public string IssuingLocation { get; set; }
        public string LicenseSuspended { get; set; }
    }
}