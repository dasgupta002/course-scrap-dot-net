using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tutorialspoint_test_API_framework.Models
{
    public class employee
    {
        public int ID { get; set; }
        [Required]  
        public string name { get; set; }
    }
}  