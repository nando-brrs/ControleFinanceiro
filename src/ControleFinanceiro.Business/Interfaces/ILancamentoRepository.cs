using ControleFinanceiro.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Business.Interfaces
{
    public interface ILancamentoRepository : IRepository<Lancamento>
    {
        Task<IEnumerable<Lancamento>> ObtemPorMesAno(int mes, int ano);
    }
}
