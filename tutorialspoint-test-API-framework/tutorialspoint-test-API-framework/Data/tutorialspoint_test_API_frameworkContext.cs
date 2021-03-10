using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace tutorialspoint_test_API_framework.Data
{
    public class tutorialspoint_test_API_frameworkContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public tutorialspoint_test_API_frameworkContext() : base("name=tutorialspoint_test_API_frameworkContext")
        {
        }

        public System.Data.Entity.DbSet<tutorialspoint_test_API_framework.Models.employee> employees { get; set; }

        public System.Data.Entity.DbSet<tutorialspoint_test_API_framework.Models.office> offices { get; set; }

        public System.Data.Entity.DbSet<tutorialspoint_test_API_framework.Models.updatedOffice> updatedOffices { get; set; }
    }
}
