using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Activity
    {
        public int Id { get; set; }
        public string ClaimReference { get; set; }
        public string LegacyActivityId { get; set; }
        public string ActivityTypeCode { get; set; }
        public string ActivityDetails { get; set; }
        public DateTime ActivityDateTime { get; set; }
        public int? PartyId { get; set; }
        public string PartyType { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedId { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedId { get; set; }
    }
}
