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

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Universidade> Universidades { get; set; }
        public DbSet<Campus> Campus { get; set; }
        public DbSet<CampusCurso> CampusCurso { get; set; }
        public DbSet<Modalidade> Modalidade { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Favorito> Favorito { get; set; }
        public DbSet<Vestibular> Vestibular { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<CampusCurso>().HasKey(cc => new { cc.CampusId, cc.CursoId });
            builder.Entity<Usuario>().ToTable("Usuarios");
            builder.Entity<IdentityRole>().ToTable("Perfis");
            builder.Entity<IdentityUserRole<string>>().ToTable("UsuarioPerfis");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UsuarioReivindicacoes");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UsuarioLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UsuarioTokens");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("PerfilReivindicacoes");

            builder.Entity<Vestibular>()
                .Property(v => v.PrecoInscricao)
                .HasPrecision(10, 2);

            AppDbSeed seed = new(builder);
        }
    }
}
