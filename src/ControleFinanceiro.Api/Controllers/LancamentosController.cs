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
            IMapper mapper)
        {
            _lancamentoRepository = lancamentoRepository;
            _lancamentoService = lancamentoService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<LancamentoViewModel>> ObterTodos()
        {
            var lancamentos = _mapper.Map<IEnumerable<LancamentoViewModel>>( await _lancamentoRepository.GetAll());

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
            if (!ModelState.IsValid) return BadRequest();

            var lancamento = _mapper.Map<Lancamento>(lancamentoViewModel);
            var result = await _lancamentoService.Add(lancamento);

            if (!result) return BadRequest();

            return Ok(lancamento);


        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<LancamentoViewModel>> Atualizar(Guid id, LancamentoViewModel lancamentoViewModel)
        {
            if (id != lancamentoViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var lancamento = _mapper.Map<Lancamento>(lancamentoViewModel);
            var result = await _lancamentoService.Update(lancamento);

            if (!result) return BadRequest();

            return Ok(lancamento);


        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<LancamentoViewModel>> Excluir(Guid id)
        {
            var lancamento = await ObterLancamento(id);

            if (lancamento == null) return NotFound();

            var result = await _lancamentoService.Remove(id);

            if (!result) return BadRequest();

            return Ok(lancamento);

        }
        public async Task<LancamentoViewModel> ObterLancamento(Guid id)
        {
            return _mapper.Map<LancamentoViewModel>(await _lancamentoRepository.GetById(id));
        }
    }
}
