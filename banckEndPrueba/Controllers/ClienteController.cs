using banckEndPrueba.Domain.IService;
using banckEndPrueba.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                cliente.estadoRegistroCliente = 1;
                var validateExistence = await _clienteService.validateClienteExistence(cliente);
                if (validateExistence)
                {
                    return BadRequest(new { message = "El Cliente " + cliente.nombreCliente + " ya existe" });
                }
                await _clienteService.saveCustomer(cliente);
                return Ok(new { message = "Cliente Registrado con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [Route("obternerListaClientes")]
        [HttpGet]
        public async Task<IActionResult> GetListCuetomer()
        {
            try
            {
                var listCustomers = await _clienteService.GetCustomersList();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{idCliente}")]
        public async Task<IActionResult> editCustomer([FromBody] Cliente cliente)
        {
            try
            {
                cliente.estadoRegistroCliente = 1;
                var clienteaEditar = await _clienteService.validateCx(cliente);
                if (clienteaEditar)
                {
                    await _clienteService.updateCx(cliente);
                    return Ok(new { message = "El registro fue ediatado con exito" });

                }
                else
                {
                    return BadRequest(new { message = "No se encontro a el Cliente" });
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idCliente}")]
        public async Task<IActionResult> EliminarCliente(int idCliente)
        {
            try
            {
                var cliente = await _clienteService.BuscarCx(idCliente);

                if (cliente == null)
                {
                    return BadRequest(new { message = "No se encontro el cliente" });
                }
                await _clienteService.deleteCx(cliente);
                return Ok(new { message = "El cliente fue eliminado con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
