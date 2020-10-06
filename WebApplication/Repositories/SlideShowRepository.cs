﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Repositories.EFCore;

namespace WebApplication.Repositories
{
    public class SlideShowRepository : GenericRepository<SlideShow>, ISlideShowRepository
    {
        public SlideShowRepository(MultiStoreContext db) : base(db)
        {

        }
    }
}
