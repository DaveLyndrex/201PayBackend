using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models.Masterfile
{
    public class DefaultPayFrequency_SetupModel
    {
        public int ID { get; set; }
        public string PayFrequency { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}