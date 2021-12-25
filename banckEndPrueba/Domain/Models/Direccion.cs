using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Domain.Models
{
    public class Direccion
    {
        public int direccionId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string provinciaDireccion { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string cantonDireccion { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string distritoDireccion { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string otrasSenasDireccion { get; set; }

        [Column(TypeName = "varchar(1)")]
        public string estadoRegistroDireccion { get; set; }

    }
}
