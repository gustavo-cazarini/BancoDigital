using BancoDigital.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoDigital.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ContaModel> Contas { get; set; }
    }
}
