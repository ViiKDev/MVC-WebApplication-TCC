using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccAspNet.Models
{
    public class HomeVM
    {
        public ApplicationUser User { get; set; }
        public List<Servico> Servicos { get; set; }
        public List<Contato> Notificacoes { get; set; }
        public Contato Formulario { get; set; }
        public List<Equipe> MEquipe { get; set; }
        public List<Carrossel> PaginasCarrossel { get; set; }
        public List<Recomendacao> Recomendacoes { get; set; }
        public List<Projeto> ItensProjeto { get; set; }
        public List<Categoria> Filtros { get; set; }
    }
}