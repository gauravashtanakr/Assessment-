using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Claim
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public int LossAdjusterId { get; set; }
        public string Policy { get; set; }
        public DateTime LossDate { get; set; }
        public int LossTypeId { get; set; }
        public string LossLoc { get; set; }
        public bool Closed { get; set; }
        public DateTime? ClosedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedId { get; set; }

        public virtual User Created { get; set; }
        public virtual User LastUpdated { get; set; }
        public virtual User LossAdjuster { get; set; }
        public virtual LossType LossType { get; set; }
    }
}
