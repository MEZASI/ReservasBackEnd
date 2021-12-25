using banckEndPrueba.Domain.IService;
using banckEndPrueba.Domain.Models;
using banckEndPrueba.DTO;
using banckEndPrueba.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace banckEndPrueba.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                usuario.estadoRegistroUsuario = 1;
                var validateExistence = await _usuarioService.validateExistence(usuario);
                if (validateExistence)
                {
                    return BadRequest(new { message = "El ususario " + usuario.usuarioUsuario + " ya existe" });
                }
                usuario.passwordUsuario = Encriptar.EncriptarPassword(usuario.passwordUsuario);
                await _usuarioService.SaveUser(usuario);
                return Ok(new { message = "Usuario Registrado con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [Route("CambiarPassword")]
        //asi se proteje el end point, despues de crear el jwt 
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]

        public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordDTO cambiarPassword)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfiguration.GetTokenIdUsuario(identity);
                // se llama a la funcion y se guarda la contrseña encriptada
                string passwordEncriptado = Encriptar.EncriptarPassword(cambiarPassword.passwordAnterior);

                var usuario = await _usuarioService.validatePassword(idUsuario, passwordEncriptado);
                // el if se encarga de comparar si la constraseña existe o no para realizar el cambio de contrseña
                if (usuario == null)
                {
                    return BadRequest(new { message = "La contraseña anetrior no es correcta" });
                }
                else
                {
                    usuario.passwordUsuario = Encriptar.EncriptarPassword(cambiarPassword.nuevoPassword);
                    await _usuarioService.updatePassword(usuario);
                    return Ok(new { message = "La contraseña se actualizo con exito" });
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [Route("obternerListaUsuariosUsuarios")]
        [HttpGet]
        public async Task<IActionResult> GetListUsers()
        {
            try
            {
                var listUsers = await _usuarioService.GetUsersList();
                return Ok(listUsers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idUsuario}")]
        public async Task<IActionResult> Eliminar(int idUsuario)
        {
            try
            {
                var usuario = await _usuarioService.BuscarUsuario(idUsuario);

                if(usuario == null)
                {
                    return BadRequest(new { message = "No se encontro el Usuario" });
                }
                await _usuarioService.EliminarUsuario(usuario);
                return Ok(new { message = "El usuario fue eliminado con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idUsuario}")]
        public async Task<IActionResult> EditUser( [FromBody] Usuario usuario)
        {
            try
            {
                var usuarioxEditar = await _usuarioService.validateUser(usuario);
                if (usuarioxEditar)
                {
                    await _usuarioService.updateUser(usuario);
                    return Ok(new { message = "El registro fue ediatado con exito" });
                    
                } else
                {
                    return BadRequest(new { message = "No se encontro el Usuario" });
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
