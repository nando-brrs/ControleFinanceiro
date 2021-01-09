using ControleFinanceiro.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObtemNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
