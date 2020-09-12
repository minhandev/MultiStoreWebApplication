using System;
using System.Collections.Generic;
using WebApplication.Repositories.EFCore;

namespace WebApplication.Models
{
    public partial class Package : IEntity
    {
        public Package()
        {
            MemberShip = new HashSet<MemberShip>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<MemberShip> MemberShip { get; set; }
    }
}
