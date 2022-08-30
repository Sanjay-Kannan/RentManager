using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Tenant
    {
        public Tenant()
        {
            Rents = new HashSet<Rent>();
        }

        public int TenantId { get; set; }
        public string TenantName { get; set; } = null!;
        public int RoomId { get; set; }
        public decimal Advance { get; set; }
        public decimal Rent { get; set; }
        public int ContactNumber { get; set; }
        public DateTime AgreementInitiation { get; set; }
        public DateTime AgreementTermination { get; set; }
        public decimal? WaterAndMaintenance { get; set; }
        public byte[]? Deleted { get; set; }

        public virtual Room Room { get; set; } = null!;
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
