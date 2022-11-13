using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class NgoAvail
    {

        public int id { get; set; }
        public string resid { get; set; }
        public int employeeid { get; set; }
        public System.DateTime sdate { get; set; }
        public System.DateTime edate { get; set; }

        public string available { get; set; }

    }
}