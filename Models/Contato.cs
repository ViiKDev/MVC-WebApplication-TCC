using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TccAspNet.Models
{
    [Table("Contato")]
    public class Contato
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public int IdServico { get; set; }
        public string Assunto { get; set; }
        public string Detalhes { get; set; }
        public string Resposta { get; set; }
        public bool Lida { get; set; } = false;
    }
}