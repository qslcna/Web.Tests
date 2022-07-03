
using Microsoft.EntityFrameworkCore;
using Pocket.Domain;

namespace Pocket.Context
{

    public class PocketEFCoreContext : DbContext
    {
        public PocketEFCoreContext(DbContextOptions<PocketEFCoreContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketItem> TicketItems { get; set; }


        public DbSet<Produce> Produces { get; set; }
        public DbSet<ProduceItem> ProduceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produce>()
                .HasMany(x => x.Items)
                .WithOne()
                .IsRequired(true);

            modelBuilder.Entity<Fix>()
                .HasMany(x => x.Items)
                 .WithOne()
                .IsRequired(true);


            modelBuilder.Entity<TicketItem>()
                .HasOne(x => x.Ticket)
                .WithMany()
                .HasForeignKey(x => x.TicketId);

            base.OnModelCreating(modelBuilder);
        }
    }


}