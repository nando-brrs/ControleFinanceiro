using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFinanceiro.Api.ViewModels;
using ControleFinanceiro.Business.Interfaces;
using ControleFinanceiro.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers
{
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
        [HttpGet]
        public async Task<IEnumerable<LancamentoViewModel>> ObterTodos()
        {

            var lancamentos = _mapper.Map<IEnumerable<LancamentoViewModel>>(await _lancamentoRepository.GetAll());

            return lancamentos;
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
