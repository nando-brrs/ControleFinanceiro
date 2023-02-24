using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using ControleFinanceiro.Api.ViewModels;
using ControleFinanceiro.Business.Interfaces;
using ControleFinanceiro.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers
{
    [Authorize]
    [Route("api/lancamentos")]
    public class LancamentosController : MainController
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly ILancamentoService _lancamentoService;
        private readonly IMapper _mapper;
        public LancamentosController(ILancamentoRepository lancamentoRepository,
            ILancamentoService lancamentoService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _lancamentoRepository = lancamentoRepository;
            _lancamentoService = lancamentoService;
            _mapper = mapper;
        }
        [HttpGet("{mes:int}/{ano:int}")]
        public async Task<IEnumerable<LancamentoViewModel>> ObterTodosPorAnoMes(int mes, int ano)
        {

            var lancamentos = _mapper.Map<IEnumerable<LancamentoViewModel>>(await _lancamentoRepository.ObtemPorMesAno(mes, ano)).OrderBy(x => x.Data);

            return lancamentos;
        }
        [HttpGet]
        public async Task<IEnumerable<LancamentoViewModel>> ObterTodos()
        {

            var lancamentos = _mapper.Map<IEnumerable<LancamentoViewModel>>(await _lancamentoRepository.GetAll()).OrderBy(x => x.Data);

            return lancamentos;
        }
        [HttpPost]
        [Route("GetPaged")]
        public IActionResult GetPaged([FromBody] LancamentoFiltroViewModel lancamentoFiltroViewModel)
        {

            List<Expression<Func<Lancamento, bool>>> where = new List<Expression<Func<Lancamento, bool>>>();

            Expression<Func<Lancamento, object>> orderBy = null;

            if (!string.IsNullOrEmpty(lancamentoFiltroViewModel.Descricao))
                where.Add(m => m.Descricao.Contains(lancamentoFiltroViewModel.Descricao));

            if (lancamentoFiltroViewModel.Data != null)
                where.Add(m => m.Data == lancamentoFiltroViewModel.Data);

            if (lancamentoFiltroViewModel.DataVencimento != null)
                where.Add(m => m.DataVencimento ==  lancamentoFiltroViewModel.DataVencimento);


            if (lancamentoFiltroViewModel.OrderBy == "Data")
                orderBy = c => c.Data;

            var result = _lancamentoRepository.GetPaged(lancamentoFiltroViewModel.PageIndex,
                                                    lancamentoFiltroViewModel.PageSize,
                                                    where,
                                                    orderBy,
                                                    lancamentoFiltroViewModel.Ascending);

            var lancamentos = _mapper.Map<IEnumerable<LancamentoViewModel>>(result.Item2);

            return Ok(new
            {
                Result = lancamentos,
                lancamentoFiltroViewModel.PageIndex,
                lancamentoFiltroViewModel.PageSize,
                Total = result.Item1
            });
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LancamentoViewModel>> ObterPorId(Guid id)
        {
            var lancamento = _mapper.Map<LancamentoViewModel>(await _lancamentoRepository.GetById(id));

            if (lancamento == null) return NotFound();

            return lancamento;
        }
        [HttpPost]
        public async Task<ActionResult<LancamentoViewModel>> Adicionar(LancamentoViewModel lancamentoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var lancamento = _mapper.Map<Lancamento>(lancamentoViewModel);
            await _lancamentoService.Add(lancamento);

            return CustomResponse(lancamentoViewModel);


        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<LancamentoViewModel>> Atualizar(Guid id, LancamentoViewModel lancamentoViewModel)
        {
            if (id != lancamentoViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var lancamento = _mapper.Map<Lancamento>(lancamentoViewModel);
            await _lancamentoService.Update(lancamento);

            return CustomResponse(lancamentoViewModel);


        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<LancamentoViewModel>> Excluir(Guid id)
        {
            var lancamento = await ObterLancamento(id);

            if (lancamento == null) return NotFound();

            await _lancamentoService.Remove(id);

            return CustomResponse(lancamento);

        }
        public async Task<LancamentoViewModel> ObterLancamento(Guid id)
        {
            return _mapper.Map<LancamentoViewModel>(await _lancamentoRepository.GetById(id));
        }
    }
}
