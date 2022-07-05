using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TccAspNet.Enums;

namespace TccAspNet.Models
{
    [Table("Equipe")]
    public class Equipe
    {

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Cargo { get; set; }
        // public string Role { get; set; }

    }

}