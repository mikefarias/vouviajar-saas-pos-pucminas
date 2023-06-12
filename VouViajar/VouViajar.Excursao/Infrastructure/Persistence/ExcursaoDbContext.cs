using Microsoft.EntityFrameworkCore;
using VouViajar.Auth.Domain.Entities.Aggregates;
using VouViajar.Excursoes.Domain.Entities;
using VouViajar.Excursoes.Domain.Entities.Aggregates;

namespace VouViajar.Excursoes.Infrastructure.Persistence
{
    public partial class ExcursaoDbContext : DbContext
    {
        public ExcursaoDbContext Instance => this;

        public DbSet<Excursao> Excursao { get; set; }
        public DbSet<Localidade> Localidade { get; set; }
        public DbSet<Situacao> Situacao { get; set; }
        public DbSet<Tipo> Tipo { get; set; }


        public ExcursaoDbContext(DbContextOptions<ExcursaoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Agencia>()
                .ToTable("Agencia", "dbo")
                .HasKey(ev => new { ev.AgenciaID });

            modelBuilder.HasDefaultSchema("Excursoes");

            modelBuilder.Entity<Excursao>().HasOne(ev => ev.Agencia).WithOne().HasForeignKey<Agencia>(a => a.AgenciaID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Excursao>().HasOne(ev => ev.Origem).WithOne().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Excursao>().HasOne(ev => ev.Destino).WithOne().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Excursao>().HasOne(ev => ev.Tipo).WithOne().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Excursao>().HasOne(ev => ev.Situacao).WithOne().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Excursao>().Property("ValorVaga").HasColumnType("decimal").HasPrecision(5);

            modelBuilder.Entity<Localidade>()
                .HasKey(ev => new { ev.LocalidadeID });

            modelBuilder.Entity<Situacao>()
                .HasKey(ev => new { ev.SituacaoID });

            modelBuilder.Entity<Tipo>()
                .HasKey(ev => new { ev.TipoID });

        }

    }
}
