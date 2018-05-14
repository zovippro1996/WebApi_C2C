﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI_C2C.Models
{
    public class WebAPI_C2CContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebAPI_C2CContext() : base("name=WebAPI_C2CContext")
        {
        }

        public System.Data.Entity.DbSet<WebAPI_C2C.Models.Rating> Ratings { get; set; }

        public System.Data.Entity.DbSet<WebAPI_C2C.Models.User> Users { get; set; }
    }
}
