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
    public class PaqueteRepository: IPaqueteRepository
    {
        private readonly AplicationDbContext _context;

        public PaqueteRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task savePackage(Paquete paquete)
        {
            _context.Add(paquete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Paquete>> GetPackagesList()
        {
            var listCustomers = await _context.TB_Paquetes.Where(x => x.estadoRegistroPaquete == 1).ToListAsync();
            return listCustomers;
        }

        public async Task<bool> validatePackage(Paquete paquete)
        {
            var validatePackage = await _context.TB_Paquetes.AnyAsync(x => x.paqueteId == paquete.paqueteId);
            return validatePackage;
        }

        public async Task updatePackage(Paquete paquete)
        {
            _context.Entry(paquete).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<Paquete> BuscarPackage(int idPaquete)
        {
            var paquete = await _context.TB_Paquetes.Where(x => x.paqueteId == idPaquete && x.estadoRegistroPaquete == 1).FirstOrDefaultAsync();
            return paquete;
        }

        public async Task deletePackage(Paquete paquete)
        {
            paquete.estadoRegistroPaquete = 0;
            _context.Entry(paquete).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


    }
}
