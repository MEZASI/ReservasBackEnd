using banckEndPrueba.Domain.IService;
using banckEndPrueba.Domain.Models;
using banckEndPrueba.Services;
using banckEndPrueba.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace banckEndPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;
        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [Route("registrarReservacion")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reserva reserva)
        {
            try
            {
                
                reserva.estadoReserva = 1;
                reserva.reservaFechaAsignacion = DateTime.Now;
                await _reservaService.saveReservation(reserva);
                return Ok(new { message = "Reserva Registrada con exito" });

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
                var listCustomers = await _reservaService.GetCustomersList();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("obternerListaPaquetes")]
        [HttpGet]
        public async Task<IActionResult> GetListPackages()
        {
            try
            {
                var listPackages = await _reservaService.GetPackagesList();
                return Ok(listPackages);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("obternerListaUsuarios")]
        [HttpGet]
        public async Task<IActionResult> GetListUsers()
        {
            try
            {
                var listUsers = await _reservaService.GetUsersList();
                return Ok(listUsers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("obternerListaReservasxUsuario")]
        [HttpGet]
        public async Task<IActionResult> GetListBooksByUser()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int IdUsuario = JwtConfiguration.GetTokenIdUsuario(identity);

                var listReservasUser = await _reservaService.GetReservaListByUser(IdUsuario);
                return Ok(listReservasUser);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [Route("obternerListaReservas")]
        [HttpGet]
        public async Task<IActionResult> GetListBooks()
        {
            try
            {

                var listReservas = await _reservaService.GetReservasList();
                return Ok(listReservas);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idReserva}")]
        public async Task<IActionResult> TerminarTarea(int idReserva)
        {
            try
            {
                var reserva = await _reservaService.BuscarBook(idReserva);

                if (reserva == null)
                {
                    return BadRequest(new { message = "No se encontro la reserva" });
                }
                await _reservaService.deleteBook(reserva);
                return Ok(new { message = "La reserva fue eliminada con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }




    }
}
