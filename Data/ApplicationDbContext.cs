using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using controleJornadas.Models;

namespace controleJornadas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Bases> Bases { get; set; } = default!;
        public DbSet<controleJornadas.Models.funcionarios> funcionarios { get; set; } = default!;
        public DbSet<controleJornadas.Models.Jornadas> Jornadas { get; set; } = default!;
    }
}
