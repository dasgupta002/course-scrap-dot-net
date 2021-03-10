using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tutorialspoint_test_API_framework.Models
{
    public class office
    {
        public int ID { get; set; }
        [Required]
        public string location { get; set; }
        public int employeeID { get; set; }
        public employee emp { get; set; }
    }
}