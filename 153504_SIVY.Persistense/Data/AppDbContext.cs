using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _153504_SIVY.Domain.Entities;

namespace _153504_SIVY.Persistense.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Song> Songs => Set<Song>();
        public DbSet<Performer> Performers => Set<Performer>();
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) => Database.EnsureCreated();
    }
}
