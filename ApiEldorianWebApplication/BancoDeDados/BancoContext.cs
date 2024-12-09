using ApiEldorianWebApplication.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiEldorianWebApplication.BancoDeDados
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<Raca> Racas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personagem>()
                .HasOne<Usuario>()
                .WithMany(u => u.Personagens)
                .HasForeignKey(f => f.idPersonagem)
                .OnDelete(DeleteBehavior.NoAction); // ao ser deletado não faça nada (pra nao deletar o usuarios provavelmente)-lobo
                                                    //Um personagem tem um usuario...

            modelBuilder.Entity<Usuario>()
                .HasMany<Personagem>()
                .WithOne(p => p.Usuario)
                .HasForeignKey(f => f.idUsuario)
                .OnDelete(DeleteBehavior.Cascade); // ao deletar usuario deletar tambem personagens
                                                   //Um usuarios tem varios Personagens...

        }
    }
}
