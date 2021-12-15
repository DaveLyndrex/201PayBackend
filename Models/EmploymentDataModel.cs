/*[10/05/2021] CN E.Patot*/
/*[10/10/2021] CN E.Patot*/
/*[10/14/2021] CN A.DIEZ*/
namespace BackEnd.Models
{
    public class EmploymentDataModel
    {
        public int id { get; set; }

        public int emp_id { get; set; }

        public string company_id { get; set; }

        public string department_id { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string EmploymentStatusID { get; set; }

        public string JobLevelID { get; set; }

        public string JobTypeID { get; set; }

        public string PositionID { get; set; }

        public string LocationID { get; set; }

        public string ProjectID { get; set; }

        public string SiteID { get; set; }

        public string ReasonID { get; set; }

        public string SubDept { get; set; }

        public string BusinessUnitID { get; set; }

        public string Section { get; set; }

        public string JobFamilyNameID { get; set; }

        public string JobCodeID { get; set; }
        public string JobType { get; set; }

        public string EmploymentTypeID { get; set; }

        public string UnionMember { get; set; }

        public string DivisionID { get; set; }

        public string GradeID { get; set; }

        public string GradeRateID { get; set; }

        public string WorkerTypeID { get; set; }

        public string CreatedDate { get; set; }

        public string ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}