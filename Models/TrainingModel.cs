/*[10/08/2021] CN E.Patot*/

namespace BackEnd.Models
{
    public class TrainingModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ActualDuration { get; set; }
        public string TypeID { get; set; }
        public string Location { get; set; }
        public string ConductedBy { get; set; }
        public string Attachments { get; set; }
        public string Remarks { get; set; }
        public string WithCertification { get; set; }
        public string ProgramFee { get; set; }
        public string IncidentialCost { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}