using banckEndPrueba.Domain.IService;
using banckEndPrueba.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace banckEndPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteController : ControllerBase
    {
        private readonly IPaqueteService _paqueteService;
        public PaqueteController(IPaqueteService paqueteService)
        {
            _paqueteService = paqueteService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Paquete paquete)
        {
            try
            {
                paquete.estadoRegistroPaquete = 1;
                await _paqueteService.savePackage(paquete);
                return Ok(new { message = "Paquete Registrado con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "Se produjo un error al insertar" + paquete.nombrePaquete + ex });

            }
        }

        [Route("obternerListaPaquetes")]
        [HttpGet]
        public async Task<IActionResult> GetListPackages()
        {
            try
            {
                var listPackages = await _paqueteService.GetPackagesList();
                return Ok(listPackages);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idUsuario}")]
        public async Task<IActionResult> editCustomer([FromBody] Paquete paquete)
        {
            try
            {
                paquete.estadoRegistroPaquete = 1;
                var paqueteaEditar = await _paqueteService.validatePackage(paquete);
                if (paqueteaEditar)
                {
                    await _paqueteService.updatePackage(paquete);
                    return Ok(new { message = "El registro fue ediatado con exito" });

                }
                else
                {
                    return BadRequest(new { message = "No se encontro a el paquete" });
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idPaquete}")]
        public async Task<IActionResult> EliminarCliente(int idPaquete)
        {
            try
            {
                var paquete = await _paqueteService.BuscarPackage(idPaquete);
                if (paquete == null)
                {
                    return BadRequest(new { message = "No se encontro el paquete" });
                }
                await _paqueteService.deletePackage(paquete);
                return Ok(new { message = "El paquete fue eliminado con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
