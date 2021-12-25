using banckEndPrueba.Domain.IService;
using banckEndPrueba.Domain.Models;
using banckEndPrueba.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _config;
        public LoginController(ILoginService loginService, IConfiguration config)
        {
            _loginService = loginService;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                usuario.passwordUsuario = Encriptar.EncriptarPassword(usuario.passwordUsuario);
                // devuelve un usuario si la contraseña y el usuasrio son validos o nulo si no sexietn alguno de los 2 
                var user = await _loginService.validateUsuario(usuario);

                if(user == null)
                {
                    return BadRequest(new { message = "Usuario o conrtraseña invalidos" });
                }
                string tokenString = JwtConfiguration.GetToken(user, _config);

                return Ok(new { token = tokenString });
            }
            catch (Exception ex)
            {

               return BadRequest(new { message = ex });
            }
        }
    }
}
