﻿using System;
using System.Collections.Generic;
using WebApplication.Repositories.EFCore;

namespace WebApplication.Models
{
    public partial class Invoice : IEntity
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool? Status { get; set; }
        public int? AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
