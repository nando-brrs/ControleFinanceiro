using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Api.ViewModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        [StringLength(150, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        [StringLength(50, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Login { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public IEnumerable<LancamentoViewModel> Lancamentos { get; set; }
    }
}
