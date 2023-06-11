using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VouViajar.Auth.Domain.Entities.Aggregates;

namespace VouViajar.Auth.Infrastructure.Persistence
{
    public class UsuarioDbContext : IdentityDbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options) { }

        public UsuarioDbContext Instance => this;

        public DbSet<Agencia> Agencia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Agencia>()
                .HasKey(ev => new { ev.AgenciaID });

        }
    }
}
