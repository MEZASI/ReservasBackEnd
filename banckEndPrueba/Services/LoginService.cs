using banckEndPrueba.Domain.IRepositories;
using banckEndPrueba.Domain.IService;
using banckEndPrueba.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Usuario> validateUsuario(Usuario usuario)
        {
            return await _loginRepository.validateUsuario(usuario);
        }
    }
}
