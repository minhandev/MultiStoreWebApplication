using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Repositories.EFCore
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}
