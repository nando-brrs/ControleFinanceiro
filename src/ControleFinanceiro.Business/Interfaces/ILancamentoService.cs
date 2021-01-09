using ControleFinanceiro.Business.Models;
using System;
using System.Threading.Tasks;

namespace ControleFinanceiro.Business.Interfaces
{
    public interface ILancamentoService
    {
        Task Add(Lancamento lancamento);
        Task Update(Lancamento lancamento);
        Task Remove(Lancamento lancamento);
    }
}
