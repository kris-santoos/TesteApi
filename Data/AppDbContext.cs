using System.Collections.Generic;
using ApiTeste.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiTeste.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Compras)
                .HasForeignKey(c => c.UsuarioId);

            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Produto)
                .WithMany(p => p.Compras)
                .HasForeignKey(c => c.ProdutoId);
        }
    }
}
