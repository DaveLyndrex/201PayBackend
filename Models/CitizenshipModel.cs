/* 07/10/2021 CN A.Diez */
/* 10/08/2021 CN E.Patot */


namespace BackEnd.Models
{
    public class CitizenshipModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string LegislationCode { get; set; }
        public string CitizenshipID { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}