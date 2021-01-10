using System;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Api.ViewModels
{
    public class LancamentoViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        [StringLength(500, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Descricao { get; set; }
        [Range(1, 100)]
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
