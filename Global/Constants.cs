using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Global
{
    public class Constants
    {
        public string SUCCESS = "Success!";
        public string ERROR = "ERROR!";
        public string CODE_OK = "200";

        public string NOT_FOUND = "Error 404";
        public string CODE_ERROR = "404";

        public bool ERROR_TRUE = true;
        public bool ERROR_FALSE = false;

        public string SUCCESS_INSERT = "Successfully Added Data";
        public string SUCCESS_UPDATE = "Successfully Updated Data";
        public string SUCCESS_DELETE = "Successfully Deleted Data";
        public string SUCCESS_RETRIEVE = "Successfully Retrieved Data";

        public string ERROR_INSERT = "Error in Adding Data";
        public string ERROR_UPDATE = "Data does not Exist";
        public string ERROR_DELETE = "Data does not Exist or is Already Deleted";
        public string ERROR_RETRIEVE = "No Data Available";
    }
}