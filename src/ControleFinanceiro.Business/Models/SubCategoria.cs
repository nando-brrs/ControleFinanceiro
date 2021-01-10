using System;
using System.Collections.Generic;

namespace ControleFinanceiro.Business.Models
{
    public class SubCategoria : Entity
    {
        public string Descricao { get; set; }
        public Guid Id_Categoria{ get; set; }
        public bool Ativo { get; set; }
        /*EF relations*/
        public Categoria Categoria { get; set; }
        public IEnumerable<Lancamento> Lancamentos { get; set; }
    }
}
