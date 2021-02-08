using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFinanceiro.Api.ViewModels;
using ControleFinanceiro.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("api/Categorias")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        public CategoriaController(ICategoriaRepository categoriaRepository,
            IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<CategoriaViewModel>> ObterTodos()
        {
            var categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.GetAll());

            return categorias;
        }
    }
}
