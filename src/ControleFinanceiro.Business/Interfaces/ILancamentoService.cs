using ControleFinanceiro.Business.Models;
using System;
using System.Threading.Tasks;

namespace ControleFinanceiro.Business.Interfaces
{
    public interface ILancamentoService
    {
        Task<bool> Add(Lancamento lancamento);
        Task<bool> Update(Lancamento lancamento);
        Task<bool> Remove(Guid id);
    }
}
