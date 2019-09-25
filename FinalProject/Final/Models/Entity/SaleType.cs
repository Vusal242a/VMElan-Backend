using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models.Entity
{
    public class SaleType:BaseEntity
    {
        [Required(ErrorMessage = "Please Fill Input")]
        [Display(Name = "Sale Type")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}