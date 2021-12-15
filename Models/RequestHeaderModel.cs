/*[10/14/2021] CN J.Layaog*/
using System;



namespace BackEnd.Models
{
    public class RequestHeaderModel
    {

        public int ID { get; set; }
        public int EmpID { get; set; }
        public string FormID { get; set; }
        public string Form { get; set; }
        public string Requester { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveType { get; set; }
        public string ChargeTo { get; set; }
        public int Paid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }

}