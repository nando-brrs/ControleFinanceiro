using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleFinanceiro.Api.ViewModels
{
    public class CategoriaViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        [StringLength(200, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        public bool Ativo { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        public TipoLancamentoViewModel TipoLancamento { get; set; }
        public IEnumerable<SubCategoriaViewModel> SubCategorias { get; set; }
    }
}
