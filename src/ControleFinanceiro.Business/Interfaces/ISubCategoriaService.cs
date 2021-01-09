using ControleFinanceiro.Business.Models;
using System.Threading.Tasks;

namespace ControleFinanceiro.Business.Interfaces
{
    public interface ISubCategoriaService
    {
        Task Add(SubCategoria subCategoria);
        Task Update(SubCategoria subCategoria);
    }
}
