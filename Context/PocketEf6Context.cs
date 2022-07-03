
using System.Data.Entity;
using Pocket.Domain;
using MySql.Data.EntityFramework;

namespace Pocket.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PocketEF6Context : DbContext
    {
        public PocketEF6Context() : base("server=localhost;user id=root;password=toor;charset=utf8;persistsecurityinfo=True;database=pocket_ef6") { }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketItem> TicketItems { get; set; }


        public DbSet<Produce> Produces { get; set; }
        public DbSet<ProduceItem> ProduceItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produce>()
                .HasMany(x => x.Items)
                .WithRequired();

            modelBuilder.Entity<Fix>()
                .HasMany(x => x.Items)
                .WithRequired();
                

            modelBuilder.Entity<TicketItem>()
                .HasRequired(x=>x.Ticket)
                .WithMany()
                .HasForeignKey(x=>x.TicketId);

            base.OnModelCreating(modelBuilder);
        }
    }


}