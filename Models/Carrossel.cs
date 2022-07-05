using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TccAspNet.Models
{
    [Table("Carrossel")]
    public class Carrossel
    {

        [Key]
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string Texto { get; set; }
        public string Descricao { get; set; }

    }

}