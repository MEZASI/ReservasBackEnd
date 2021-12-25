using banckEndPrueba.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<Usuario> validateUsuario(Usuario usuario);
    }
}
