using ControleFinanceiro.Business.Interfaces;
using ControleFinanceiro.Business.Models;
using ControleFinanceiro.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace ControleFinanceiro.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }

        }
        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidate) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidate);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;

        }
    }
}
