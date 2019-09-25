using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models.Entity
{
    public class Admin:BaseEntity
    {
        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(500)]
        public string Password { get; set; }
    }
}