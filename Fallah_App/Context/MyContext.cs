using Microsoft.EntityFrameworkCore;
using Fallah_App.Models;

namespace Fallah_App.Context
{
    public class MyContext:DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<CategoryTerre> categoryTerres { get; set; }
        public DbSet<ConseilPlante> conseilPlantes { get; set; }
        public DbSet<ConseilTerre> conseilTerres { get; set; }
        public DbSet<Demande> demandes { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Plante> plantes { get; set; }
        public DbSet<Resultat> resultats { get; set; }
        public DbSet<Sol> sols { get; set; }
        public DbSet<Terre> terres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* modelBuilder.Entity<Resultat>()
                 .HasOne(w => w.ConseilPlante)
                 .WithOne(c => c.resultat)
                 .OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<Resultat>()
                 .HasOne(w => w.agriculteurForme)
                 .WithMany(c => c.resultats)
                 .OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<AgriculteurNotification>()
                 .HasOne(w => w.agriculteur)
                 .WithMany(c => c.AgriculteurNotifications)
                 .OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<AgriculteurNotification>()
                 .HasOne(w => w.notification)
                 .WithMany(c => c.AgriculteurNotifications)
                 .OnDelete(DeleteBehavior.Restrict);*/

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Agriculteur>("Agriculteur")
                .HasValue<AgriculteurForme>("AgriculteurForme")
                .HasValue<WebMaster>("Webmaster");
                

        }
        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {
        }
    }
}
