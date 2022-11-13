using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Zero_Hunger.Models.Frestaurent;

namespace Zero_Hunger.Models
{

    [MetadataType(typeof(employeeMetaData))]
    public partial class employee
    {
        public class employeeMetaData
        {
            [DisplayName("Employee Name")]
            public string employeename { get; set; }

            [DisplayName("Password")]
            public string password { get; set; }

            [DisplayName("Mobile No.")]
            public int mobile { get; set; }

        }

    }
}