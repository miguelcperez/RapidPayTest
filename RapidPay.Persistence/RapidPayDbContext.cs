using Microsoft.EntityFrameworkCore;
using RapidPay.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Persistence
{
    public class RapidPayDbContext : DbContext
    {
        public RapidPayDbContext(DbContextOptions<RapidPayDbContext> options)
            : base(options)
        {

        }

        public DbSet<Card> Cards { get; set; }
    }
}
