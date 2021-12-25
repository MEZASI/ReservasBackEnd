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
    public class ClienteRepository: IClienteRepository
    {
        private readonly AplicationDbContext _Context;

        public ClienteRepository(AplicationDbContext Context)
        {
            _Context = Context;
        }

        public async Task saveCustomer(Cliente cliente)
        {
            _Context.Add(cliente);
            await _Context.SaveChangesAsync();
        }

        public async Task<bool> validateClienteExistence(Cliente cliente)
        {
            var validateExistence = await _Context.TB_Clientes.AnyAsync(x => x.cedulaCliente == cliente.cedulaCliente);
            return validateExistence;

        }

        public async Task<List<Cliente>> GetCustomersList()
        {
            var listCustomers = await _Context.TB_Clientes.Where(x => x.estadoRegistroCliente == 1).ToListAsync();
            return listCustomers;
        }

        public async Task<bool> validateCx(Cliente cliente)
        {
            var validateCx = await _Context.TB_Clientes.AnyAsync(x => x.clienteId == cliente.clienteId);
            return validateCx;
        }

        public async Task updateCx(Cliente cliente)
        {
            _Context.Entry(cliente).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
        }

        public async Task<Cliente> BuscarCx(int idCliente)
        {
            var cliente = await _Context.TB_Clientes.Where(x => x.clienteId == idCliente && x.estadoRegistroCliente == 1).FirstOrDefaultAsync();
            return cliente;
        }

        public async Task deleteCx(Cliente cliente)
        {
            cliente.estadoRegistroCliente = 0;
            _Context.Entry(cliente).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
        }
    }
}
