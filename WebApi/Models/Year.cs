using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Year
    {
        public Year()
        {
            Bills = new HashSet<Bill>();
            Rents = new HashSet<Rent>();
        }

        public int YearId { get; set; }
        public int Year1 { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
