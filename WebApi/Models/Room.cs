using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Room
    {
        public Room()
        {
            Tenants = new HashSet<Tenant>();
        }

        public int PropertyId { get; set; }
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string Description { get; set; } = null!;
        public int Floor { get; set; }
        public string? Fixtures { get; set; }
        public byte[]? Deleted { get; set; }

        public virtual Property Property { get; set; } = null!;
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}
