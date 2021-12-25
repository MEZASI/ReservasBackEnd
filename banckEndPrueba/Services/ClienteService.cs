using banckEndPrueba.Domain.IRepositories;
using banckEndPrueba.Domain.IService;
using banckEndPrueba.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Services
{
    public class ClienteService: IClienteService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task saveCustomer(Cliente cliente)
        {
            await _clienteRepository.saveCustomer(cliente);
        }

        public async Task<bool> validateClienteExistence(Cliente cliente)
        {
            return await _clienteRepository.validateClienteExistence(cliente);
        }


        public async Task<List<Cliente>> GetCustomersList()
        {
            return await _clienteRepository.GetCustomersList();
        }

        public async Task updateCx(Cliente cliente)
        {
            await _clienteRepository.updateCx(cliente);
        }

        public async Task<bool> validateCx(Cliente cliente)
        {
            return await _clienteRepository.validateCx(cliente);
        }

        public async Task deleteCx(Cliente cliente)
        {
            await _clienteRepository.deleteCx(cliente);
        }

        public async Task<Cliente> BuscarCx(int idCliente)
        {
            return await _clienteRepository.BuscarCx(idCliente);
        }

    }
}
