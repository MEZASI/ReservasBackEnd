using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace banckEndPrueba.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(20)")]
        public string usuarioUsuario { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string passwordUsuario { get; set; }
        
        [Column(TypeName = "varchar(100)")]
        public string nombreUsuario { get; set; }      
        
        [Column(TypeName = "varchar(100)")]
        public string correoUsuario { get; set; }
       
        [Column(TypeName = "varchar(10)")]
        public string rolUsuario { get; set; }

        
        public int estadoRegistroUsuario { get; set; }


    }
}
