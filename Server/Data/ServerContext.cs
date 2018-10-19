using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Models
{
    public class ServerContext : DbContext
    {
        public ServerContext (DbContextOptions<ServerContext> options)
            : base(options)
        {
        }

        public DbSet<RecyclingMachine> RecyclingMachine { get; set; }
        public DbSet<Bottle> Bottle { get; set; }
        public DbSet<CharacterClass> CharacterClass { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cola>();
            builder.Entity<NukeCola>();
            builder.Entity<Whiskey>();
            builder.Entity<Vodka>();
            builder.Entity<Wine>();
            builder.Entity<GinOfDestruction>();

            builder.Entity<Brute>();
            builder.Entity<Speedy>();
            builder.Entity<Hoarder>();
            builder.Entity<DefaultClass>();

            base.OnModelCreating(builder);
        }

        public DbSet<Server.Models.Player> Player { get; set; }
    }
}
