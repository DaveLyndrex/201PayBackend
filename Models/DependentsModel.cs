/*[10/08/2021] CN E.Patot*/

namespace BackEnd.Models
{
    public class DependentsModel
    {
        public int ID { get; set; }
        public string EmpID { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string SuffixID { get; set; }
        public string BirthDate { get; set; }
        public string Relation { get; set; }
        public string WTax { get; set; }
        public string Medical { get; set; }
        public string GPA { get; set; }
        public string DepType { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}