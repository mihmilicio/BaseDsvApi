using BaseDsvApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseDsvApi.Data
{
    public class DataContext : DbContext
    {
        // Constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        // Lista de propriedades das classes que vão virar tabelas no banco
        public DbSet<Produto> Produtos { get; set; }
    }
}