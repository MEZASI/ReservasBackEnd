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
    public class LoginRepository: ILoginRepository
    { 
        private readonly AplicationDbContext  _Context;
        public LoginRepository(AplicationDbContext Context)
        {
            _Context = Context;
        }

        public async Task<Usuario> validateUsuario(Usuario usuario) 
        {
            var user = await _Context.TB_Usuarios.Where(x => x.usuarioUsuario == usuario.usuarioUsuario && x.passwordUsuario == usuario.passwordUsuario).FirstOrDefaultAsync();
            return user;

        }

    }
}
