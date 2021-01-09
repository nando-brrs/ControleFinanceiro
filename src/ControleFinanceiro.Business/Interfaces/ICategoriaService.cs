using ControleFinanceiro.Business.Models;
using System.Threading.Tasks;

namespace ControleFinanceiro.Business.Interfaces
{
    public interface ICategoriaService
    {
        Task Add(Categoria categoria);
        Task Update(Categoria categoria);
    }
}
