using System;

namespace BonsaiWebApp.Models
{
    public class EntityBase
    {

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public DateTime? DeleteAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
