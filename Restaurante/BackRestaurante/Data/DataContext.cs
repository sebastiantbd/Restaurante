using Microsoft.EntityFrameworkCore;
using ModeloRestaurante.Entidades;

namespace BackRestaurante.Data

{
        public class DataContext : DbContext
        {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {

        }

        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }

 }

