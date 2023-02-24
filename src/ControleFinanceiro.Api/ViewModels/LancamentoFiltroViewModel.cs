using System;

namespace ControleFinanceiro.Api.ViewModels
{
    public class LancamentoFiltroViewModel : PagedParam
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? DataVencimento { get; set; }
    }
}
