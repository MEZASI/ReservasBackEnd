using banckEndPrueba.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Domain.IService
{
    public interface ILoginService
    {
        Task<Usuario> validateUsuario(Usuario usuario);
    }
}
