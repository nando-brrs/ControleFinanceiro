using System.Collections.Generic;

namespace ControleFinanceiro.Business.Models
{
    public class Categoria : Entity
    {
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public TipoLancamento TipoLancamento { get; set; }
        /*EF relations*/
        public IEnumerable<SubCategoria> SubCategorias { get; set; }
    }
}
