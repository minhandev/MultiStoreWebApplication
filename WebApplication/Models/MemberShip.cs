using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class MemberShip
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? Price { get; set; }
        public int? PackageId { get; set; }
        public int? AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Package Package { get; set; }
    }
}
