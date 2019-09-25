using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models.Entity
{
    public class Agents:BaseEntity
    {
      
        public string Image { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [Display(Name = "Agent Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(200)]
        public string Vacation { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Please Fill Input")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(100)]
        public string FacebookLogo { get; set; }
        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(100)]
        public string FacebookLink { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(100)]
        public string InstagramLogo { get; set; }
        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(100)]
        public string InstagramLink { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(100)]
        public string TwitterLogo { get; set; }
        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(100)]
        public string TwitterLink { get; set; }

    }
}