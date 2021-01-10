using ControleFinanceiro.Business.Interfaces;
using ControleFinanceiro.Business.Models;
using ControleFinanceiro.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace ControleFinanceiro.Business.Services
{
    public class SubCategoriaService : BaseService, ISubCategoriaService
    {
        private readonly ISubCategoriaRepository _subcategoriaRepository;
        public SubCategoriaService(ISubCategoriaRepository subcategoriaRepository,
            INotificador notificador) : base(notificador)
        {
            _subcategoriaRepository = subcategoriaRepository; 
        }
        public async Task Add(SubCategoria subCategoria)
        {
            if (!ExecutarValidacao(new SubCategoriaValidation(), subCategoria)) return;

            await _subcategoriaRepository.Add(subCategoria);
        }

        public Task Update(SubCategoria subCategoria)
        {
            throw new NotImplementedException();
        }
    }
}
