/*[10/14/2021] CN J.Layaog*/
using System;

namespace BackEnd.Models
{
    public class KioskUserModel
    {
        
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Email { get; set; }
        public string Description { get; set; }
    }
    public class RequestAttachmentModel
    {
        public int RequestID { get; set; }
        public string Attachment { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class RequestModel
    {
        public int RequestID { get; set; }

        public string Attachment { get; set; }
        public int EmpID { get; set; }
        public int Sequence { get; set; }
        public string ModifiedBy { get; set; }
    }


    //REQUEST DETAILS MODELS
    public class RequestDetails
    {

        // OVERTIME =  ID, RequestID, StartDate, StartTime, EndTime, EndDate, Reason, OTOptions, CreatedDate, ModifiedDate, ModifiedBy
        // COA = ID, RequestID, Date, StartTime, StartTimeDate, EndTime, EndTimeDate, StartTime2, StartTimeDate2, EndTime2, EndTimeDate2, Reason, CreatedDate, ModifiedDate, ModifiedBy
        // LEAVE = ID, RequestID, StartDate, Span, EndDate, Span2, Date, StartTime, EndTime, Reason, CreatedDate, ModifiedDate, ModifiedBy
        // SHIFT =  ID, RequestID, Date, Shift, Reason, CreatedDate, ModifiedDate, ModifiedBy
        public int RequestID { get; set; }
        public string StartDate { get; set; }

        public int Span1 { get; set; }
        public string Date { get; set; }
       
        public string StartTime { get; set; }
        public string Shift { get; set; }
        public string StartTimeDate { get; set; }
        public string EndTime { get; set; }

        public string EndTimeDate { get; set; }
        public string EndDate { get; set; }
        public int Span2 { get; set; }

        public string StartTime2 { get; set; }

        public string StartTimeDate2 { get; set; }
        public string EndTime2 { get; set; }

        public string EndTimeDate2 { get; set; }
        public string Reason { get; set; }
        public string ModifiedBy { get; set; }
    }

  /*  public int RequestID { get; set; }
    public DateTime StartDate { get; set; }

    public int Span { get; set; }
    public string Date { get; set; }

    public string StartTime { get; set; }
    public string Shift { get; set; }
    public DateTime StartTimeDate { get; set; }
    public string EndTime { get; set; }

    public DateTime EndTimeDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Span2 { get; set; }

    public string StartTime2 { get; set; }

    public DateTime StartTimeDate2 { get; set; }
    public string EndTime2 { get; set; }

    public DateTime EndTimeDate2 { get; set; }
    public string Reason { get; set; }
    public string ModifiedBy { get; set; }*/




    public class ApprovalWorkflow
    {

        public int RequestID { get; set; }
        public int EmpID { get; set; }

        public string Request { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class Approval
    {

        public string View { get; set; }
        public string Name { get; set; }

        public int Status { get; set; }
        public int RequestID { get; set; }

      
    }




}