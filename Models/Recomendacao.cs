using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TccAspNet.Models
{
    [Table("Recomendacao")]
    public class Recomendacao
    {

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Profissao { get; set; }
        public string Texto { get; set; }

    }

}