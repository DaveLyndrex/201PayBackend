/*[10/08/2021] CN E.Patot*/
namespace BackEnd.Models
{
    public class EducationModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string School { get; set; }
        public string Course { get; set; }
        public string Attachment { get; set; }
        public string Remarks { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}