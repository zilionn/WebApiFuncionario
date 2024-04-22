using Microsoft.EntityFrameworkCore;
using WEBAPI_Funcionario.Models;
namespace WEBAPI_Funcionario.DataContent {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }

    }
}
