using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using UniVest.Models;

namespace UniVest.Data
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Universidade> Universidades { get; set; }
        public DbSet<Campus> Campi { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Vestibular> Vestibulares { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Renomeia as tabelas do Identity se quiser
            builder.Entity<Usuario>().ToTable("Usuarios"); 
            builder.Entity<IdentityRole>().ToTable("Perfis");
            builder.Entity<IdentityUserRole<string>>().ToTable("UsuarioPerfis");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UsuarioReivindicacoes");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UsuarioLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UsuarioTokens");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("PerfilReivindicacoes");

            // Outras configurações personalizadas se desejar
        }
    }
}
