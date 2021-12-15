using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// [10 / 12 / 2021 CN CRUBIO]

namespace BackEnd.Models
{
    public class ShiftModel
    {
        public string ShiftCode { get; set; }
        public string ShiftName { get; set; }
        public string In1 { get; set; }
        public string Out1 { get; set; }
        public string In2 { get; set; }
        public string Out2 { get; set; }

    }
}