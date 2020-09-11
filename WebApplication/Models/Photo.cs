using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Featured { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
