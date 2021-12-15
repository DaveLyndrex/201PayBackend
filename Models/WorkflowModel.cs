/*[10/05/2021] CN E.Patot*/

namespace BackEnd.Models
{
    public class WorkflowModel
    {
        public int ID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int EmpID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string EmailType { get; set; }
        public string PrimaryFlag { get; set; }
        public string SendCredsEmailFlag { get; set; }
        public string UserNameMatchingFlag { get; set; }
        public string RaterID { get; set; }
        public string ApproverID { get; set; }
        public string MaxApprover { get; set; }
        public string ApprovalGroupID { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}