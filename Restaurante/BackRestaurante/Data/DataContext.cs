using Microsoft.EntityFrameworkCore;
using ModeloRestaurante.Entidades;

namespace BackRestaurante.Data

{
        public class DataContext : DbContext
        {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {
            }

            public DbSet<Chef> Chef { get; set; }
        }

 }

