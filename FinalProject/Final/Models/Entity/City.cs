using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models.Entity
{
    public class City:BaseEntity
    {
        [Required(ErrorMessage = "Please Fill Input")]
        [Display(Name = "City Name")]
        [StringLength(100)]
        public string Name { get; set; }

        public string Image { get; set; }

        public ICollection<HomeInfo> homeInfos {get;set;}
    }
}