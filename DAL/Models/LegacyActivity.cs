using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class LegacyActivity
    {
        public string ClaimReference { get; set; }
        public int Id { get; set; }
        public DateTime ActivityDate { get; set; }
        public string CategoryInd { get; set; }
        public int CompletedBy { get; set; }
        public string AdhocOrPartyInd { get; set; }
        public int? PartyId { get; set; }
        public int? AdhocPartyId { get; set; }
        public string TypeCode { get; set; }
        public string Detail { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedId { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedId { get; set; }
    }
}
