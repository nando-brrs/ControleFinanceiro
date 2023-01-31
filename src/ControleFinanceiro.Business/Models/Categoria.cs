using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ControleFinanceiro.Business.Models
{
    public class Categoria : Entity
    {
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public TipoLancamento TipoLancamento { get; set; }
        public IEnumerable<SubCategoria> SubCategorias { get; set; }
    }
}
