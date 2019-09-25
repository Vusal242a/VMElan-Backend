using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        public int? CreatedId { get; set; }

        [ScaffoldColumn(false)]
        public int? ModifiedId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        public int? DeletedId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DeletedDate { get; set; }
    }
}