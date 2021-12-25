using banckEndPrueba.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Domain.IRepositories
{
    public interface IReservaRepository
    {
        Task<List<Cliente>> GetCustomersList();

        Task<List<Paquete>> GetPackagesList();

        Task<List<Usuario>> GetUsersList();

        Task<List<Reserva>> GetReservaListByUser( int IdUsuario);

        Task saveReservation(Reserva reserva);

        Task<List<Reserva>> GetReservasList();

        Task deleteBook(Reserva reserva);

        Task<Reserva> BuscarBook(int idReserva);


    }
}
