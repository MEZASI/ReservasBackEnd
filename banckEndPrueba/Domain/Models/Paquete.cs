using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Domain.Models
{
    public class Paquete
    {
        public int paqueteId { get; set; }
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string nombrePaquete { get; set; }
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string descripcionPaquete { get; set; }

        public int estadoRegistroPaquete { get; set; }

    }
}
