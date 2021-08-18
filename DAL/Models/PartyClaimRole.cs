using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class PartyClaimRole
    {
        public int Id { get; set; }
        public string PartyTypeCode { get; set; }
        public string ClaimReference { get; set; }
        public string AdhocOrPartyInd { get; set; }
        public int? PartyId { get; set; }
        public int? AdhocPartyId { get; set; }
        public string PartyReference { get; set; }
        public string ContactName { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedId { get; set; }
    }
}
