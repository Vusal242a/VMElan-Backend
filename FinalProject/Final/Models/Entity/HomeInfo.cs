using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models.Entity
{
    public class HomeInfo:BaseEntity
    {
        [Required(ErrorMessage = "Please Fill Input")]
        [Display(Name = "Home Street Address")]
        [StringLength(100)]
        public string Name { get; set; }

        public string BackgroundImage { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(50)]
        public string Price { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(30)]
        public string Square { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        public byte Garage { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        public byte Bathroom { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        public byte Bedroom { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [StringLength(500)]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public virtual Categories Category { get; set; }

        public int SaleTypeId { get; set; }
        public virtual SaleType SaleType { get; set; }

        public int AgentsId { get; set; }
        public virtual Agents Agents { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<Image> Image { get; set; }

        public virtual ICollection<PlanImage> PlanImage { get; set; }
    }
}