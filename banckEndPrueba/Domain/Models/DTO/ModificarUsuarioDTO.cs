using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.DTO
{
    public class ModificarUsuarioDTO
    {
        public int Id { get; set; }

        public string usuarioUsuario { get; set; }


        public string nombreUsuario { get; set; }

        public string correoUsuario { get; set; }

        public string rolUsuario { get; set; }

    }
}
