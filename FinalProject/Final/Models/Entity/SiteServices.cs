using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models.Entity
{
    public class SiteServices:BaseEntity
    {
        [Required(ErrorMessage = "Please Fill Input")]
        [Display(Name = "Service Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(400)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please use fontawesome.com for Logo")]
        [StringLength(200)]
        public string LogoClass { get; set; }
    }
}