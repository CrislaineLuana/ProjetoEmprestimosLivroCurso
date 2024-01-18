using Microsoft.EntityFrameworkCore;

namespace ProjetoEmprestimosLivroCurso.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
