using System;

namespace ControleFinanceiro.Business.Models
{
    public class Lancamento : Entity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public DateTime? DataVencimento { get; set; }
        public bool? Pago { get; set; }
        public bool? Recorrente { get; set; }
        public TipoLancamento TipoLancamento { get; set; }
        public Guid IdSubCategoria { get; set; }
        public Guid IdUsuario { get; set; }
        /*EF Relations*/
        public SubCategoria SubCategoria { get; set; }
        public Usuario Usuario { get; set; }
    }
}
