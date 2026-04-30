using Microsoft.EntityFrameworkCore;
using ApiUsuarios.Models;

namespace ApiUsuarios.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<Personagem> Personagens { get; set; }
    }
}