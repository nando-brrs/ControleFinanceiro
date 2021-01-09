using ControleFinanceiro.Business.Models;
using ControleFinanceiro.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Data.Repository
{
    public class SubCategoriaRepository : Repository<SubCategoria>, ISubCategoriaRepository
    {
        public SubCategoriaRepository(ControleFinanceiroContext context) : base(context) { }
    }
}
