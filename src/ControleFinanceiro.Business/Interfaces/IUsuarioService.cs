using ControleFinanceiro.Business.Models;
using System.Threading.Tasks;

namespace ControleFinanceiro.Business.Interfaces
{
    public interface IUsuarioService
    {
        Task Add(Usuario usuario);
        Task Update(Usuario usuario);
    }
}
