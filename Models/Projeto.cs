using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TccAspNet.Models
{
    [Table("Projeto")]
    public class Projeto
    {

        [Key]
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public int Filtro { get; set; }
        [ForeignKey("Filtro")]
        public Categoria Categoria { get; set; }

    }

}