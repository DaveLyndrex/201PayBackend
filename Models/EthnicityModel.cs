/*[10/08/2021] CN E.Patot*/
namespace BackEnd.Models
{
    public class EthnicityModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
      
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Ethnicity { get; set; }
        public string PrimaryFlag { get; set; }

        public string CreatedDate { get; set; }

        public string ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public string SourceSystemOwner { get; set; }

        public string SourceSystemID { get; set; }

    }


}