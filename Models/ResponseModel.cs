using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class ResponseModel
    {
        public string message { get; set; }
        public string status { get; set; }
        public string code { get; set; }
        public Boolean error { get; set; }
        public Object data { get; set; }
    }
}