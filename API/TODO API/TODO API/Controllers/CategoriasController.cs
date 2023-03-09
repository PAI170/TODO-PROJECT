using Microsoft.AspNetCore.Mvc;
using TODO_API.Data.Models;
using TODO_API.Services;
using Microsoft.EntityFrameworkCore;
using TODO_API.DataTransferObjects;
using AutoMapper;

namespace TODO_API.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoriasService _categoriasservice;
        public CategoriasController(IMapper mapper, ICategoriasService categoriasService)
        {
            this._mapper = mapper;
            this._categoriasservice = categoriasService;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> ListCategorias()
        {
            List<Categorias> list =  await this._categoriasservice
                                                .ListCategorias() 
                                                .ToListAsync();

            APIResponse response = new()
            {
                Data = list.Select(c => this._mapper.Map<Categorias, GetCategoriasDTO>(c))
            };

            return response;
        }
    }
}
