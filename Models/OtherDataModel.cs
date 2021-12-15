/*[10/07/2021] CN E.Patot*/
namespace BackEnd.Models
{
    public class OtherDataModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Attachments { get; set; }
        public string Remarks { get; set; }
        public string FieldName { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}