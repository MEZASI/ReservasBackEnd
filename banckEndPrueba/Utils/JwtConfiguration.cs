using banckEndPrueba.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace banckEndPrueba.Utils
{
    public class JwtConfiguration
    {
        public static string GetToken(Usuario usuarioInfo, IConfiguration config )
        {
            string SecretKey = config["Jwt:SecretKey"];
            string Issuer = config["Jwt:Issuer"];
            string Audience = config["Jwt:Audience"];


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));// pasamos el SecretKey qu esta en appsettigns 
            // se asigna lo que tare la linea de arriba en security key y se lo pasamos al SigningCredentials
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);  

            var claims = new[]
           {     // se generan las reclamaciones 
                new Claim(JwtRegisteredClaimNames.Sub, usuarioInfo.usuarioUsuario),// se reclama el usuario el login 
                new Claim("nombreUsuario", usuarioInfo.nombreUsuario),// se reclama el nombre del ususario 
                new Claim(JwtRegisteredClaimNames.Sub, usuarioInfo.rolUsuario),// reclamamos el rol del usuario. 
                new Claim("idUsuario", usuarioInfo.Id.ToString()),// se recklama el nombre el id del usuario 
                new Claim("roleUsuario", usuarioInfo.rolUsuario)

            };


            // Creamos el token 
            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static int GetTokenIdUsuario(ClaimsIdentity identity)
        {
            if(identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                foreach (var claim in claims)
                {
                    if (claim.Type == "idUsuario")
                    {
                        return int.Parse(claim.Value);
                    }

                }
            }
            return 0; 
        }

    }
}
