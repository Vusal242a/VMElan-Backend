using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models.Entity
{
    public class Image:BaseEntity
    {
        [Required(ErrorMessage ="Please add one or more Photos")]
        public string Photo { get; set; }

        public int HomeInfoId { get; set; }
        public virtual HomeInfo HomeInfo { get; set; }
    }
}