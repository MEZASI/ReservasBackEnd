using banckEndPrueba.Domain.IRepositories;
using banckEndPrueba.Domain.IService;
using banckEndPrueba.Domain.Models;
using banckEndPrueba.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Services
{
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task SaveUser(Usuario usuario)
        {
            await _usuarioRepository.SaveUser(usuario);
        }

        public async Task<bool> validateExistence(Usuario usuario)
        {
            return await _usuarioRepository.ValidateExistence(usuario);
        } 

        public async Task<Usuario> validatePassword(int idUsuario, string passwordAterior)
        {
            return await _usuarioRepository.validatePassword( idUsuario, passwordAterior);
        }

        public async Task updatePassword(Usuario usuario)
        {
            await _usuarioRepository.updatePassword(usuario);
        }

        public async Task<List<Usuario>> GetUsersList()
        {
            return await _usuarioRepository.GetUsersList();
        }

        public async Task<Usuario> BuscarUsuario(int idUsuario)
        {
            return await _usuarioRepository.BuscarUsuario(idUsuario);
        }

        public async Task EliminarUsuario(Usuario usuario)
        {
            await _usuarioRepository.EliminarUsuario(usuario);
        }

        public async Task updateUser(Usuario usuario)
        {
            await _usuarioRepository.updateUser(usuario);
        }

        public async Task<bool> validateUser(Usuario usuario)
        {
            return await _usuarioRepository.validateUser(usuario);
        }
    }
}
