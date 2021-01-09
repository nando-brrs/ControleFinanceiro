using FluentValidation;

namespace ControleFinanceiro.Business.Models.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(l => l.Nome)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado")
                .Length(10, 150)
                .WithMessage("O Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(l => l.Login)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado")
                .Length(10, 50)
                .WithMessage("O Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(l => l.Senha)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado");

            RuleFor(l => l.Ativo)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado");

            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado");

        }
    }
}
