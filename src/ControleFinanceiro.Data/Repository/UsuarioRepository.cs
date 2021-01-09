using ControleFinanceiro.Business.Interfaces;
using ControleFinanceiro.Business.Models;
using ControleFinanceiro.Data.Context;

namespace ControleFinanceiro.Data.Repository
{

    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ControleFinanceiroContext context) : base(context) { }
    }
}
