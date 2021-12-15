/*[10/07/2021] CN E.Patot*/


namespace BackEnd.Models
{
    public class EmergencyContactModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternateNumber { get; set; }
        public string Relationship { get; set; }
        public string Address { get; set; }
        public string MOTH { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}