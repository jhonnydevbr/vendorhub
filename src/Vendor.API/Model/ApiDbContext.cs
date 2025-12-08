using Microsoft.EntityFrameworkCore;

namespace vendorhub.Model;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }
    
    public DbSet<Fornecedor> Fornecedores { get; set; }
}