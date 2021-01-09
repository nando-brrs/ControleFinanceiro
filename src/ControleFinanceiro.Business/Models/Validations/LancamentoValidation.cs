using FluentValidation;

namespace ControleFinanceiro.Business.Models.Validations
{
    public class LancamentoValidation : AbstractValidator<Lancamento>
    {
        public LancamentoValidation()
        {
            RuleFor(l => l.Descricao)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado")
                .Length(10, 500)
                .WithMessage("O Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(l => l.Valor)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado");

            RuleFor(l => l.Valor)
                .GreaterThan(0).WithMessage("O Campo {PropertyName} precisa ser maior que {ComparisionValue}");

            RuleFor(l => l.Data)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado");


            When(l => l.TipoLancamento == TipoLancamento.DESPESAS, () =>
            {
                RuleFor(l => l.DataVencimento)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado");

                RuleFor(l => l.Pago)
                    .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado");

            });

        }
    }
}
