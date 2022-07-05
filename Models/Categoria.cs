using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TccAspNet.Models
{
    [Table("Categoria")]
    public class Categoria
    {

        [Key]
        public int Id { get; set; }
        public string NomeFiltro { get; set; }
        // public string ReferenciaFiltro { get; set; }

    }

}