using System.ComponentModel.DataAnnotations;

namespace Final.Models.Entity
{
    public class Rewiev:BaseEntity
    {
        [Required(ErrorMessage = "Please Fill Input")]
        [Display(Name = "Quest Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [Display(Name = "Your Job")]
        [StringLength(100)]
        public string Vacantion { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [Display(Name = "Rate Us")]
        [StringLength(100)]
        public string Rate { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        [Display(Name = "Comment")]
        [StringLength(100)]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Please Fill Input")]
        public string Image { get; set; }

        public bool isPosted { get; set; }

    }
}