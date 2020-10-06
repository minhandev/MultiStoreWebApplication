using System;
using System.Collections.Generic;
using WebApplication.Repositories.EFCore;

namespace WebApplication.Models
{
    public partial class Photo : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public bool Featured { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
