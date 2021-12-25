using banckEndPrueba.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Domain.IRepositories
{
    public interface IPaqueteRepository
    {
        Task savePackage(Paquete paquete);

        Task<List<Paquete>> GetPackagesList();

        Task updatePackage(Paquete paquete);

        Task<bool> validatePackage(Paquete paquete);

        Task deletePackage(Paquete paquete);

        Task<Paquete> BuscarPackage(int idPaquete);
    }
}
