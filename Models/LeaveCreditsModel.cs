/* 10/08/2021 CN E.Patot */
namespace BackEnd.Models
{
    public class LeaveCreditsModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public int LeaveCreditYear { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string LeaveType { get; set; }
        public string Beginning { get; set; }
        public string CarriedOver { get; set; }
        public string CarriedOverExpiry { get; set; }
         public string ModifiedBy { get; set; }
        public string CreatedDate { get; set; }

        public string ModifiedDate { get; set; }

    }


}