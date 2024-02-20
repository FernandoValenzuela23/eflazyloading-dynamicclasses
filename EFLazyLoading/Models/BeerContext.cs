using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLazyLoading.Models
{
    public class BeerContext : DbContext
    {
        public BeerContext(DbContextOptions<BeerContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Beer> Beers { get; set; }

    }
}
