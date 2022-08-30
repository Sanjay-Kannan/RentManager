using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Month
    {
        public Month()
        {
            Bills = new HashSet<Bill>();
            Rents = new HashSet<Rent>();
        }

        public int MonthId { get; set; }
        public string MonthName { get; set; } = null!;

        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
