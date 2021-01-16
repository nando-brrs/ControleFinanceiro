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
        public Guid Id_SubCategoria { get; set; }
        public Guid Id_Usuario { get; set; }
        /*EF Relations*/
        virtual public SubCategoria SubCategoria { get; set; }
        virtual public Usuario Usuario { get; set; }
    }
}
