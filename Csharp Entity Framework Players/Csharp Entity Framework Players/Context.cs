using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Entity_Framework_Players
{
    public class Context : DbContext
    {
        public DbSet <Player> Players { get; set; }
        public DbSet <Team> Teams { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=EFPlayers;" +
                "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
