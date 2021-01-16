using System;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Api.ViewModels
{
    public class LancamentoViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataVencimento { get; set; }
        public bool? Pago { get; set; }
        public bool? Recorrente { get; set; }
        public TipoLancamentoViewModel TipoLancamento { get; set; }
        public Guid IdSubCategoria { get; set; }
        public Guid IdUsuario { get; set; }
        /*EF Relations*/
        public SubCategoriaViewModel SubCategoria { get; set; }
        public UsuarioViewModel Usuario { get; set; }
    }
}
