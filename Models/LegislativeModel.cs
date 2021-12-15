/* 07/10/2021 CN A.Diez */
/*[10/09/2021] CN E.Patot*/

namespace BackEnd.Models
{
    public class LegislativeModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string HighestEducationalLevel { get; set; }
        public string MaritalStatus { get; set; }
        public string MaritalStatusDate { get; set; }
        public string Sex { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}