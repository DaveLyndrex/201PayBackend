using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class Division_SetupModel
    {
        public int ID { get; set; }
        public string DivisionCode { get; set; }
        public string DivisonName { get; set; }
        public string mf_division_setupcol { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}