using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFinanceiro.Api.ViewModels;
using ControleFinanceiro.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers
{
    [Authorize]
    [Route("api/SubCategorias")]
    public class SubCategoriaController : Controller
    {
        private readonly ISubCategoriaRepository _subCategoriaRepository;
        private readonly IMapper _mapper;
        public SubCategoriaController(ISubCategoriaRepository subCategoriaRepository,
            IMapper mapper)
        {
            _subCategoriaRepository = subCategoriaRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("ObterTodos")]
        public async Task<IEnumerable<SubCategoriaViewModel>> ObterTodos()
        {
            var subCategorias = _mapper.Map<IEnumerable<SubCategoriaViewModel>>(await _subCategoriaRepository.GetAll());

            return subCategorias;
        }
        [HttpGet]
        public async Task<IEnumerable<SubCategoriaViewModel>> ObterSubcategoriasPorCodigoCategoria(Guid categoriaId)
        {
            var subCategorias = _mapper.Map<IEnumerable<SubCategoriaViewModel>>(await _subCategoriaRepository.GetAll()).Where(s => s.Id_Categoria  == categoriaId);

            return subCategorias;
        }
    }
}
