using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI_C2C.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Phonenumber { get; set; }
        public float Point { get; set; }
    }
}