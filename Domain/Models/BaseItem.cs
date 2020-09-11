using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class BaseItem : BaseModel
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int? LabelId { get; set; }
        public int? UserId { get; set; }
    }
}
