using banckEndPrueba.Domain.IRepositories;
using banckEndPrueba.Domain.IService;
using banckEndPrueba.Domain.Models;
using banckEndPrueba.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Services
{
    public class ReservaService : IReservaService   
    {
        private readonly IReservaRepository _reservaRepository;
        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<List<Cliente>> GetCustomersList()
        {
            return await _reservaRepository.GetCustomersList();
        }
        public async Task<List<Paquete>> GetPackagesList()
        {
            return await _reservaRepository.GetPackagesList();
        }

        public async Task<List<Reserva>> GetReservaListByUser(int IdUsuario)
        {
            return await _reservaRepository.GetReservaListByUser(IdUsuario);
        }

        public async Task<List<Usuario>> GetUsersList()
        {
            return await _reservaRepository.GetUsersList();
        }

        public async Task saveReservation(Reserva reserva)
        {
            await _reservaRepository.saveReservation(reserva);
        }

        public async Task<List<Reserva>> GetReservasList()
        {
            return await _reservaRepository.GetReservasList();
        }

        public async Task deleteBook(Reserva reserva)
        {
            await _reservaRepository.deleteBook(reserva);
        }

        public async Task<Reserva> BuscarBook(int idReserva)
        {
            return await _reservaRepository.BuscarBook(idReserva);
        }


    }
}
