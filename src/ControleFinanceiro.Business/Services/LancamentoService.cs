using ControleFinanceiro.Business.Interfaces;
using ControleFinanceiro.Business.Models;
using ControleFinanceiro.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace ControleFinanceiro.Business.Services
{
    public class LancamentoService : BaseService, ILancamentoService
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public LancamentoService(ILancamentoRepository lancamentoRepository,
            INotificador notificador) : base(notificador)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task Add(Lancamento lancamento)
        {
            if (!ExecutarValidacao(new LancamentoValidation(), lancamento)) return;

            await _lancamentoRepository.Add(lancamento);

        }

        public async Task Update(Lancamento lancamento)
        {
            if (!ExecutarValidacao(new LancamentoValidation(), lancamento)) return;

            await _lancamentoRepository.Update(lancamento);
        }

        public async Task Remove(Lancamento lancamento)
        {
            await _lancamentoRepository.Remove(lancamento);
        }
    }
}
