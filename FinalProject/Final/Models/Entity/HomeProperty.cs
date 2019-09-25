using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models.Entity
{
    public class HomeProperty:BaseEntity
    {
        [Required(ErrorMessage = "Please Fill Input")]
        [Display(Name = "Property Name")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}