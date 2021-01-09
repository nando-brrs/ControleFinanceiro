using ControleFinanceiro.Business.Interfaces;
using ControleFinanceiro.Business.Models;
using ControleFinanceiro.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace ControleFinanceiro.Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository,
            INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task Add(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return;

            await _usuarioRepository.Add(usuario);
        }

        public async Task Update(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return;

            await _usuarioRepository.Add(usuario);
        }
    }
}
