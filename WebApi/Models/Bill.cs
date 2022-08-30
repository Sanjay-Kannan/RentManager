using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Bill
    {
        public Bill()
        {
            Rents = new HashSet<Rent>();
        }

        public int BillId { get; set; }
        public int PropertyId { get; set; }
        public int MonthId { get; set; }
        public int YearId { get; set; }
        public string BillDescription { get; set; } = null!;
        public decimal BillAmounr { get; set; }

        public virtual Month Month { get; set; } = null!;
        public virtual Property Property { get; set; } = null!;
        public virtual Year Year { get; set; } = null!;
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
