using ControleFinanceiro.Business.Interfaces;
using ControleFinanceiro.Business.Models;
using ControleFinanceiro.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace ControleFinanceiro.Business.Services
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository,
            INotificador notificador) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task Add(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return;

            await _categoriaRepository.Add(categoria);
        }

        public async Task Update(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return;

            await _categoriaRepository.Add(categoria);
        }
    }
}
