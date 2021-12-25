using banckEndPrueba.Domain.IRepositories;
using banckEndPrueba.Domain.Models;
using banckEndPrueba.DTO;
using banckEndPrueba.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Persistence.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly AplicationDbContext _context;
        public UsuarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveUser(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Usuario usuario)
        {
            var validateExistence = await _context.TB_Usuarios.AnyAsync(x => x.usuarioUsuario == usuario.usuarioUsuario);
            return validateExistence;
        }

        public async Task<Usuario> validatePassword(int idUsuario, string passwordAnterior)
        {
            var usuario = await _context.TB_Usuarios.Where(x => x.Id == idUsuario && x.passwordUsuario == passwordAnterior).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task updatePassword(Usuario usuario)
        {
            _context.Update(usuario);

            await _context.SaveChangesAsync(); 
        }
        public async Task<List<Usuario>> GetUsersList()
        {
            var listCustomers = await _context.TB_Usuarios.Where(x => x.estadoRegistroUsuario == 1)
                                                           .Select(U => new Usuario
                                                           {
                                                               Id = U.Id,
                                                               usuarioUsuario = U.usuarioUsuario,
                                                               passwordUsuario = U.passwordUsuario,
                                                               nombreUsuario = U.nombreUsuario,
                                                               correoUsuario = U.correoUsuario,
                                                               rolUsuario = U.rolUsuario                                                                                                

                                                           }).ToListAsync();
            return listCustomers;
        }

        public async Task<Usuario> BuscarUsuario(int idUsuario)
        {
            var usuario = await _context.TB_Usuarios.Where(x => x.Id == idUsuario && x.estadoRegistroUsuario == 1).FirstOrDefaultAsync();
            return usuario;
        } 

        public async Task EliminarUsuario(Usuario usuario)
        {
            usuario.estadoRegistroUsuario = 0;
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> validateUser(Usuario usuario)
        {
            var validateUser = await _context.TB_Usuarios.AnyAsync(x => x.Id == usuario.Id);
            return validateUser;
        }

        public async Task updateUser(Usuario usuario)
        {

            var usuarioEditado = new Usuario
            {
                Id = usuario.Id,
                usuarioUsuario = usuario.usuarioUsuario,
                passwordUsuario = usuario.passwordUsuario,
                nombreUsuario = usuario.nombreUsuario,
                correoUsuario = usuario.correoUsuario,
                rolUsuario = usuario.rolUsuario,
                estadoRegistroUsuario = 1
            };
            _context.Entry(usuarioEditado).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
