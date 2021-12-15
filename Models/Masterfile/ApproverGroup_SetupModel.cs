/*[10/05/2021] CN E.Patot*/

namespace BackEnd.Models.Masterfile
{
    public class ApproverGroup_SetupModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Sequence { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}