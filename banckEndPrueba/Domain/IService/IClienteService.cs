using banckEndPrueba.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Domain.IService
{
    public interface IClienteService
    {
        Task saveCustomer(Cliente cliente);
        Task<bool> validateClienteExistence(Cliente cliente);

        Task<List<Cliente>> GetCustomersList();

        Task updateCx(Cliente cliente);

        Task<bool> validateCx(Cliente cliente);

        Task deleteCx(Cliente cliente);

        Task<Cliente> BuscarCx(int idCliente);
    }
}
