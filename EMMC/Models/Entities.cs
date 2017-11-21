using System.Data.Entity;

namespace EMMC.Models
{
    public class Entities : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<LoginAdministrador> LoginAdministradores { get; set; }
        
    }
}
