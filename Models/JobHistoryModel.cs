/*[10/08/2021] CN E.Patot*/

namespace BackEnd.Models
{
    public class JobHistoryModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }
        public string Responsibilities { get; set; }
        public string ReasonForLeaving { get; set; }
        public string Attachment { get; set; }
        public string Remarks { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}