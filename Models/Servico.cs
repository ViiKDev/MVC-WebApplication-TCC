using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TccAspNet.Models
{
    [Table("Servico")]
    public class Servico
    {

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

    }

}