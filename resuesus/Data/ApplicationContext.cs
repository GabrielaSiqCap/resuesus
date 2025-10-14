using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using resuesus.Models;

namespace resuesus.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Historico> Historicos { get; set; }
        public DbSet<Notificacoes> Notificacoes { get; set; }

        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<RedeConhecida> RedeConhecidas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
