using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models.Masterfile
{
    public class ShiftSet_SetupModel
    {
        public int ID { get; set; }
        public string ShiftSetName { get; set; }
        public int Mon{ get; set; }
        public int Tue { get; set; }
        public int Wed { get; set; }
        public int Thu { get; set; }
        public int Fri{ get; set; }
        public int Sat { get; set; }
        public int Sun { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}