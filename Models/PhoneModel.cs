/* 07/10/2021 CN A.Diez */
/*[10/10/2021] CN E.Patot*/

namespace BackEnd.Models
{
    public class PhoneModel
    {
        public int ID { get; set; }
        public string EmpID { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string PhoneType { get; set; }
        public string Extension { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}