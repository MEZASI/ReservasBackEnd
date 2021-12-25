using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Domain.Models
{
    public class Cliente
    {
        
        public int clienteId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string cedulaCliente { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string nombreCliente { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string segundoNombreCliente { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string primerApellidoCliente { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string segundoApellidoCliente { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string correoCliente { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string telefonoCliente { get; set; }

        public int estadoRegistroCliente { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string ciudadCliente { get; set; }

    }
}
