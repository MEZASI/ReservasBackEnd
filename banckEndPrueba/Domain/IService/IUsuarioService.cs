using banckEndPrueba.Domain.Models;
using banckEndPrueba.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Domain.IService
{
    public interface IUsuarioService
    {
        Task SaveUser(Usuario usuario);
        Task<bool> validateExistence(Usuario usuario);
        Task<Usuario> validatePassword(int idUsuario, string passwordAnterior);
        Task updatePassword(Usuario usuario);

        Task<List<Usuario>> GetUsersList();

        Task<Usuario> BuscarUsuario(int idUsuario);

        Task EliminarUsuario(Usuario usuario);

        Task updateUser(Usuario usuario);

        Task<bool> validateUser(Usuario usuario);
    }
}
