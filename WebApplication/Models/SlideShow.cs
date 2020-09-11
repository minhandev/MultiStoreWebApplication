using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class SlideShow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
