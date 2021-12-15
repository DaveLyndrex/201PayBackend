/*[10/10/2021] CN E.Patot*/

namespace BackEnd.Models
{
    public class VisaModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string EffectiveStartDate { get; set; }
        public string EffectiveEndDate { get; set; }
        public string VisaPermitType { get; set; }
        public string EntryDate { get; set; }
        public string CurrentVisaPermit { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}