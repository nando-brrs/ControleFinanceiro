using FluentValidation;

namespace ControleFinanceiro.Business.Models.Validations
{
    public class SubCategoriaValidation : AbstractValidator<SubCategoria>
    {
        public SubCategoriaValidation()
        {
            RuleFor(l => l.Descricao)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado")
                .Length(10, 200)
                .WithMessage("O Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(l => l.Ativo)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado");

        }
    }
}
