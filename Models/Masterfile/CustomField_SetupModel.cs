using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models.Masterfile
{
    public class CustomField_SetupModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}