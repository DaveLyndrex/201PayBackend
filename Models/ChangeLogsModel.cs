using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class ChangeLogsModel
    {
        public int EmpID { get; set; } // Employee ID
        public string Table { get; set; } // Table Name Updated
        public string Column { get; set; } // Column of Table Updated
        public int Row { get; set; } // Row ID of Table
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int Action { get; set; } // 1 - Insert 2- Update - 3 Delete
        public string ModifiedBy { get; set;}
    }
}