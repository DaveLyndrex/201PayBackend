/*[10/08/2021] CN E.Patot*/

namespace BackEnd.Models
{
    public class DeductionModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string StartDate { get; set; }
        public string DeductionID { get; set; }
        public string TotalAmount { get; set; }
        public string DeductionAmount { get; set; }
        public string FrequencyID { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}