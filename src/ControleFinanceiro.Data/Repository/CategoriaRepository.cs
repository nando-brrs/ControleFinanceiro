using ControleFinanceiro.Business.Interfaces;
using ControleFinanceiro.Business.Models;
using ControleFinanceiro.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ControleFinanceiroContext context) : base(context) { }

        override public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await Db.Categorias.AsNoTracking()
                 .Include(u => u.SubCategorias).ToListAsync();
        }
    }
}
