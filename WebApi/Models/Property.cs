using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Property
    {
        public Property()
        {
            BillsNavigation = new HashSet<Bill>();
            Rooms = new HashSet<Room>();
        }

        public int PropertyId { get; set; }
        public string Address { get; set; } = null!;
        public int? Bills { get; set; }
        public int? Misc { get; set; }

        public virtual ICollection<Bill> BillsNavigation { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
