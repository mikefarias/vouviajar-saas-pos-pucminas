using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VouViajar.Auth.Infrastructure.Persistence
{
    public class UsuarioDbContext : IdentityDbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options) { }
    }
}
