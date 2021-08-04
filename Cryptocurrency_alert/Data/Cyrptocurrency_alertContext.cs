using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cryptocurrency_alert.Data
{
    public class Cyrptocurrency_alertContext : DbContext
    {
        public Cyrptocurrency_alertContext(DbContextOptions<Cyrptocurrency_alertContext> options)
            : base(options)
        {
        }

    }
}
