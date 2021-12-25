using banckEndPrueba.Domain.IRepositories;
using banckEndPrueba.Domain.Models;
using banckEndPrueba.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Persistence.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AplicationDbContext _Context;

        public ReservaRepository(AplicationDbContext Context)
        {
            _Context = Context;
        }

        public async Task<List<Cliente>> GetCustomersList()
        {
            var listCustomers = await _Context.TB_Clientes.Where(x => x.estadoRegistroCliente == 1).ToListAsync();
            return listCustomers;
        }
        public async Task<List<Paquete>> GetPackagesList()
        {
            var listCustomers = await _Context.TB_Paquetes.Where(x => x.estadoRegistroPaquete == 1).ToListAsync();
            return listCustomers;
        }

        public async Task<List<Reserva>> GetReservaListByUser(int IdUsuario)
        {
            var listBooksByUsers = await _Context.TB_Reservas.Where(x => x.estadoReserva == 1 && x.usuarioId == IdUsuario)
                                                                       .Select(r => new Reserva
                                                                       {
                                                                           reservaId = r.reservaId,
                                                                           descripcionTarea = r.descripcionTarea,
                                                                           reservaFecha = r.reservaFecha,
                                                                           cliente = new Cliente
                                                                           {
                                                                               clienteId = r.cliente.clienteId,
                                                                               nombreCliente = r.cliente.nombreCliente,
                                                                               telefonoCliente = r.cliente.telefonoCliente,
                                                                               correoCliente = r.cliente.correoCliente,
                                                                               cedulaCliente = r.cliente.cedulaCliente
                                                                           },
                                                                           usuario = new Usuario
                                                                           {
                                                                               Id = r.usuario.Id,
                                                                               usuarioUsuario = r.usuario.usuarioUsuario
                                                                           },
                                                                           paquete = new Paquete
                                                                           {
                                                                               paqueteId = r.paquete.paqueteId,
                                                                               nombrePaquete = r.paquete.nombrePaquete
                                                                           }
                                                                       }).ToListAsync();
            return listBooksByUsers;
        }

        public async Task<List<Usuario>> GetUsersList()
        {
            var listCustomers = await _Context.TB_Usuarios.Where(x => x.estadoRegistroUsuario == 1).ToListAsync();
            return listCustomers;
        }

        public async Task saveReservation(Reserva reserva)
        {
            _Context.Add(reserva);
            await _Context.SaveChangesAsync();
        }

        public async Task<List<Reserva>> GetReservasList()
        {
            var listReservas = await _Context.TB_Reservas.Where(x => x.estadoReserva == 1)
                                                       .Select(r => new Reserva
                                                       {
                                                           reservaId = r.reservaId,
                                                           descripcionTarea = r.descripcionTarea,
                                                           reservaFecha = r.reservaFecha,
                                                           reservaFechaAsignacion = r.reservaFechaAsignacion,
                                                           cliente = new Cliente
                                                           {
                                                               clienteId = r.cliente.clienteId,
                                                               nombreCliente = r.cliente.nombreCliente,
                                                               telefonoCliente = r.cliente.telefonoCliente,
                                                               correoCliente = r.cliente.correoCliente
                                                           },
                                                           usuario = new Usuario
                                                           {
                                                               Id = r.usuario.Id,
                                                               usuarioUsuario = r.usuario.usuarioUsuario
                                                           },
                                                           paquete = new Paquete
                                                           {
                                                               paqueteId = r.paquete.paqueteId,
                                                               nombrePaquete = r.paquete.nombrePaquete
                                                           }
                                                       }).ToListAsync();
            return listReservas;


        }

        public async Task<Reserva> BuscarBook(int idReserva)
        {
            var reserva = await _Context.TB_Reservas.Where(x => x.reservaId == idReserva && x.estadoReserva == 1).FirstOrDefaultAsync();
            return reserva;
        }

        public async Task deleteBook(Reserva reserva)
        {
            reserva.estadoReserva = 0;
            _Context.Entry(reserva).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
        }


    }
}
