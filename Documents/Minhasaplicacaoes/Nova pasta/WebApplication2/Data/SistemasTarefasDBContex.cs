using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace SistemaDeTarefas.Data
{
    public class SistemasTarefasDBContex : DbContext
    {
        public SistemasTarefasDBContex(DbContextOptions<SistemasTarefasDBContex> options) 
            : base(options)
        { 
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
