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

        public async Task<bool> Add(Lancamento lancamento)
        {
            if (!ExecutarValidacao(new LancamentoValidation(), lancamento)) return false;

            await _lancamentoRepository.Add(lancamento);

            return true;
        }

        public async Task<bool> Update(Lancamento lancamento)
        {
            if (!ExecutarValidacao(new LancamentoValidation(), lancamento)) return false;

            await _lancamentoRepository.Update(lancamento);

            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            var lancamento = await _lancamentoRepository.GetById(id);

            if (lancamento == null) return false;

            await _lancamentoRepository.Remove(lancamento);

            return true;
        }
    }
}
