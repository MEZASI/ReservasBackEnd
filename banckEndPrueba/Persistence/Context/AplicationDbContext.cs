using banckEndPrueba.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Persistence.Context
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Usuario> TB_Usuarios { get; set; }
        public DbSet<Cliente> TB_Clientes { get; set; }
        public DbSet<Direccion> TB_Direcciones { get; set; }
        public DbSet<Paquete> TB_Paquetes { get; set; }
        public DbSet<Reserva> TB_Reservas { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }
    }
}
