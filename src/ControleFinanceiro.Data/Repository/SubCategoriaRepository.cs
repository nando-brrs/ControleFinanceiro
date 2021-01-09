using ControleFinanceiro.Business.Models;
using ControleFinanceiro.Business.Repository;
using ControleFinanceiro.Data.Context;

namespace ControleFinanceiro.Data.Repository
{
    public class SubCategoriaRepository : Repository<SubCategoria>, ISubCategoriaRepository
    {
        public SubCategoriaRepository(ControleFinanceiroContext context) : base(context) { }
    }
}
