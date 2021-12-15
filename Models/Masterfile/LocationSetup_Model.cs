using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class LocationSetup_Model
    {
        public int ID { get; set; }
        public string Location { get; set; }
        public string EffectiveStartDate { get; set; }
        public string EffectiveEndDate { get; set; }
        public string SetCode { get; set; }
        public string ActiveStatus { get; set; }
        public string MainPhoneAreaCode { get; set; }
        public string MainPhoneCountryCode { get; set; }
        public string MainPhoneExtension { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string LeiInformationCategory { get; set; }
        public string LegislationCode { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string SourceSystemOwner { get; set; }
        public string SourceSystemID { get; set; }
    }
}