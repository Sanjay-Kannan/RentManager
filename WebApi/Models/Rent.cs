using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Rent
    {
        public int PaymentId { get; set; }
        public int MonthId { get; set; }
        public int YearId { get; set; }
        public int TenantId { get; set; }
        public decimal RentPaid { get; set; }
        public int BillId { get; set; }
        public decimal TotalBill { get; set; }

        public virtual Bill Bill { get; set; } = null!;
        public virtual Month Month { get; set; } = null!;
        public virtual Tenant Tenant { get; set; } = null!;
        public virtual Year Year { get; set; } = null!;
    }
}
