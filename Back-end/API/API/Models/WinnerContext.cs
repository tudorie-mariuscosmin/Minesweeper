using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class WinnerContext:DbContext
    {
        public WinnerContext(DbContextOptions<WinnerContext> options)
            :base(options)
        {

        }

        public DbSet<Winner> Winners { get; set; }

    }
}
