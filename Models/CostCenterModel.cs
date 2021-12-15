/*[10/14/2021] CN E.Patot*/

namespace BackEnd.Models
{
    public class CostCenterModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CostCenterID { get; set; }
        public string TypeID { get; set; }
        public string Value { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string CompanyID { get; set; }
        public string PrimaryID { get; set; }
    }
}