using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Domain.Models
{
    public class Reserva
    {

        public int reservaId { get; set; }

        public int paqueteId { get; set; }
        public Paquete paquete { get; set; }

        public int estadoReserva { get; set; }

        public int clienteId { get; set; }
        public Cliente cliente { get; set; }

        public int usuarioId { get; set; }
        public Usuario usuario { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string descripcionTarea { get; set; }

        public DateTime  reservaFecha { get; set; }

        public DateTime reservaFechaAsignacion { get; set; }

    }
}
