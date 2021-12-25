using banckEndPrueba.Domain.IRepositories;
using banckEndPrueba.Domain.IService;
using banckEndPrueba.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Services
{
    public class PaqueteService: IPaqueteService
    {
        private readonly IPaqueteRepository _paqueteRepository;

        public PaqueteService(IPaqueteRepository paqueteRepository)
        {
            _paqueteRepository = paqueteRepository;
        }

        public async Task savePackage(Paquete paquete)
        {
            await _paqueteRepository.savePackage(paquete);
        }

        public async Task<List<Paquete>> GetPackagesList()
        {
            return await _paqueteRepository.GetPackagesList();
        }

        public async Task updatePackage(Paquete paquete)
        {
            await _paqueteRepository.updatePackage(paquete);
        }

        public async Task<bool> validatePackage(Paquete paquete)
        {
            return await _paqueteRepository.validatePackage(paquete);
        }

        public async Task deletePackage(Paquete paquete)
        {
            await _paqueteRepository.deletePackage(paquete);
        }

        public async Task<Paquete> BuscarPackage(int idPaquete)
        {
            return await _paqueteRepository.BuscarPackage(idPaquete);
        }
    }
}
