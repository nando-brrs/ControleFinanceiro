using ControleFinanceiro.Business.Interfaces;
using ControleFinanceiro.Business.Models;
using ControleFinanceiro.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Repository
{
    public class LancamentoRepository : Repository<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(ControleFinanceiroContext context) : base(context) { }

        override public async Task<IEnumerable<Lancamento>> GetAll()
        {
            return await Db.Lancamentos.AsNoTracking()
                 .Include(u => u.SubCategoria).ThenInclude(u => u.Categoria)
                 .Include(u => u.Usuario).ToListAsync();
        }

        public Task<IEnumerable<Lancamento>> ObtemPorMesAno(int mes, int ano)
        {
            return Search(x => x.Data.Month == mes && x.Data.Year == ano);
        }
    }
}
