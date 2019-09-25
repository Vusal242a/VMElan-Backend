using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models.Entity
{
    public class SiteInfo: BaseEntity
    {
        [Required(ErrorMessage = "Please Fill Input")]
        public string Logo { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(100)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(500)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(100)]
        public string WorkTime { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(200)]
        public string Facebook { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(200)]
        public string Twitter { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(200)]
        public string Instagram { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(200)]
        public string LinkedIn { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(200)]
        public string Pinterest { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(1000)]
        public string AboutUsText { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(1000)]
        public string OurQualityText { get; set; }

    }
}