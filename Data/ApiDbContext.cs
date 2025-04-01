using Livraria.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
    }

}