using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
