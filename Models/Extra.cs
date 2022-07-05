using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TccAspNet.Models
{
    [Table("Extra")]
    public class Extra
    {

        [Key]
        public int Id { get; set; }
        public string Link { get; set; }
        public string Horario { get; set; }
        public string Endereco { get; set; }

    }

}