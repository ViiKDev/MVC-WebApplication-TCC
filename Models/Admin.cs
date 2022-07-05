using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TccAspNet.Models
{
    [Table("Admin")]
    public class Admin
    {

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
       public string Email { get; set; }
        [StringLength(11)]
        public string Celular { get; set; }
        [StringLength(45)]
        public string Nome { get; set; }
        [StringLength(45)]
        public string Profissao { get; set; }
        [StringLength(100)]
        public string Link { get; set; }


    }


}