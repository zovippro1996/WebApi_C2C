using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI_C2C.Models
{
    public class Rating
    {
        public int Id { get; set; }
        
        // Foreign Key
        public int Userrating { get; set; }
        // Foreign Key
        public int Userrated { get; set; }
        [Required]
        public string Point { get; set; }
    }
}