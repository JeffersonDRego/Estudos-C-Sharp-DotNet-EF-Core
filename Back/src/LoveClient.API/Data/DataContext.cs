using LoveClient.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LoveClient.API.Data
{
    
  
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
        public DbSet<Evento> Eventos { get; set; }
    }
} 