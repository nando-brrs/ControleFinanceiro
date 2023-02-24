using AutoMapper;
using ControleFinanceiro.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;

namespace ControleFinanceiro.Api.Controllers
{
    [Authorize]
    [Route("api/dahsboard")]
    public class DashboardController : MainController
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public DashboardController(ILancamentoRepository lancamentoRepository,
            INotificador notificador) : base(notificador)
        {
            _lancamentoRepository = lancamentoRepository;
        }
        [HttpGet("{mes:int}/{ano:int}")]
        [Route("DespesasDiarias")]
        public async Task<IActionResult> DespesasDiarias(int mes, int ano)
        {

            var grouped = from p in await _lancamentoRepository.Search(x => x.Data.Year == ano && x.Data.Month == mes)
                          orderby p.Data.Date
                          group p by new { p.Data} into d
                          select new { d.Key.Data, valor = d.Sum(d => d.Valor) } ;


            return Ok(new
            {
                grouped
            });
        }
       
    }
}
