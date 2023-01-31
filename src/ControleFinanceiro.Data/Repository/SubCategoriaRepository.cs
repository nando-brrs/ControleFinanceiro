using ControleFinanceiro.Business.Interfaces;
using ControleFinanceiro.Business.Models;
using ControleFinanceiro.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Repository
{
    public class SubCategoriaRepository : Repository<SubCategoria>, ISubCategoriaRepository
    {
        public SubCategoriaRepository(ControleFinanceiroContext context) : base(context) { }
        override public async Task<IEnumerable<SubCategoria>> GetAll()
        {
            return await Db.SubCategorias.AsNoTracking()
                 .Include(u => u.Categoria).ToListAsync();
        }
    }
}
