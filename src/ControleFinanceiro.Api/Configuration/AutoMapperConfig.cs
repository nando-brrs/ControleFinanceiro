using AutoMapper;
using ControleFinanceiro.Api.ViewModels;
using ControleFinanceiro.Business.Models;

namespace ControleFinanceiro.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Lancamento, LancamentoViewModel>().ReverseMap();
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<SubCategoria, SubCategoriaViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioLoginViewModel>().ReverseMap();
        }
    }
}
