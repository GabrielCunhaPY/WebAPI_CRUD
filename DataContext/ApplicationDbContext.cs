using Microsoft.EntityFrameworkCore;
using WebAPI_Estudo.Models;

namespace WebAPI_Estudo.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }

    }
}
