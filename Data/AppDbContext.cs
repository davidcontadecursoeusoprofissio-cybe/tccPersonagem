using Microsoft.EntityFrameworkCore;
using tccDiarioDeMonstros.Models;

namespace tccDiarioDeMonstros.Data
{
    public class AppDbContext
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
            {
            }
            public Dbset<Elemento> Elementos { get; set; }
        }
        
    }
}