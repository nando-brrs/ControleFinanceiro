using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ControleFinanceiro.Business.Models
{
    public class SubCategoria : Entity
    {
        public string Descricao { get; set; }
        public Guid Id_Categoria{ get; set; }
        public bool Ativo { get; set; }
        /*EF relations*/
        virtual public Categoria Categoria { get; set; }
        virtual public IEnumerable<Lancamento> Lancamentos { get; set; }
    }
}
