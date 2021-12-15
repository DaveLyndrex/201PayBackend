/*[10/09/2021] CN E.Patot*/


namespace BackEnd.Models
{
    public class PassportModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string IssueDate { get; set; }
        public string ExpirationDate { get; set; }
        public string LegislationCode { get; set; }
        public string PassportType { get; set; }
        public string PassportNumber { get; set; }
        public string IssuingAuthority { get; set; }
        public string IssuingCountry { get; set; }
        public string IssuingLocation { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}