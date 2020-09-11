using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class Account
    {
        public Account()
        {
            Invoice = new HashSet<Invoice>();
            MemberShip = new HashSet<MemberShip>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StorePhone { get; set; }
        public string StoreWebsite { get; set; }
        public string StoreLogo { get; set; }
        public bool Status { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<MemberShip> MemberShip { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
