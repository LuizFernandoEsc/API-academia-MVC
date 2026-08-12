
using Academia.Models;
using Microsoft.EntityFrameworkCore;

namespace Academia.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options):base(options)
        {

        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
