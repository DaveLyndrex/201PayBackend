/*[10/09/2021] CN E.Patot*/

namespace BackEnd.Models
{
    public class NIDModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string LegislationCode { get; set; }
        public string IssueDate { get; set; }
        public string NationalIdentifierType { get; set; }
        public string NationalIdentifierNumber { get; set; }
        public string PrimaryFlag { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string SourceSystemOwner { get; set; }
        public string SourceSystemID { get; set; }
    }
}