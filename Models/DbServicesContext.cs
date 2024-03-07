using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Crud_Login_Mvc.Models
{
    public class DbServicesContext:DbContext
    {
        public DbSet<Employee> tbl_emp {  get; set; }   

        
    }
}